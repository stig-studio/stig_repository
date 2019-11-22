using Employees_database.modules;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Employee_database {

    /// <summary>
    /// Логика взаимодействия для add_empl_page.xaml
    /// </summary>
    public partial class add_empl_page : Window {

        OpenFileDialog dialog;

        public add_empl_page() {
            InitializeComponent();
        }

        private void btn_add_Click( object sender, RoutedEventArgs e ) {

            if( this.txtb_last_name.Text == "" ) {
                this.lb_error.Content = "Last name can`t be empty";
                return;
            }

            if( this.txtb_first_name.Text == "" ) {
                this.lb_error.Content = "First name can`t be empty";
                return;
            }

            if( this.txtb_patronymic.Text == "" ) {
                this.lb_error.Content = "Patronymic name can`t be empty";
                return;
            }

            if( this.dt_birthday.Text == "" ) {
                this.lb_error.Content = "Birthday can`t be empty";
                return;
            }

            if( this.txtb_position.Text == "" ) {
                this.lb_error.Content = "Position can`t be empty";
                return;
            }

            if( this.dt_employment.Text == "" ) {
                this.lb_error.Content = "Employment date can`t be empty";
                return;
            }

            if ( this.txtb_order.Text == "" ){
                this.lb_error.Content = "Order number date can`t be empty";
                return;
            }

            byte[] img_bytes = null;

            FileInfo file_info = new FileInfo( dialog.FileName );

            using( FileStream fs = file_info.Open( FileMode.Open ) ) {

                using( BinaryReader reader = new BinaryReader( fs ) ) {
                    img_bytes = reader.ReadBytes( ( int )file_info.Length );
                }
            }

            string sql_query = $@"
            
            insert into dbo.Employees values (

                '{ txtb_last_name.Text }',
                '{ txtb_first_name.Text }',
                '{ txtb_patronymic.Text }',
                '{ DateTime.Parse( dt_birthday.Text ).ToString( "yyyy-MM-dd" ) }',
                '{ txtb_position.Text }',
                '{ DateTime.Parse( dt_employment.Text ).ToString( "yyyy-MM-dd" ) }',
                 { ( ( dt_dismissal.Text == "" ) ? "NULL" : "'" + DateTime.Parse( dt_dismissal.Text ).ToString( "yyyy-MM-dd" ) + "'" ) },
                '{ txtb_order.Text }',
                 @photo,
                '{ txtb_address.Text }',
                '{ txtb_phone.Text }'
                
            )   ";

            SqlCommand cmd = new SqlCommand( sql_query, sql_data.connection );

            SqlParameter param = new SqlParameter {

                ParameterName = "photo",
                IsNullable = true,
                SqlDbType = SqlDbType.VarBinary,
                Value = img_bytes

            };

            cmd.Parameters.Add( param );

            cmd.ExecuteNonQuery();

            this.Close();
        }

        private void btn_select_Click( object sender, RoutedEventArgs e ) {

            dialog = new OpenFileDialog();
            dialog.ShowDialog();

            txtb_photo.Text = dialog.FileName;
        }
    }
}