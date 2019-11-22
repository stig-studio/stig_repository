using Employees_database.modules;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для add_user_page.xaml
    /// </summary>

    public partial class add_user_page : Window {

        public add_user_page() {
            InitializeComponent();
        }

        private void btn_add_Click( object sender, RoutedEventArgs e ) {
            add_new_user();
        }

        private void Window_Loaded( object sender, RoutedEventArgs e ) {

            string sql_query = $@"
            
            select
	            e.id id,
	            ( e.last_name + ' ' + e.first_name + ' ' + e.patronymic_name ) full_name
            from dbo.Employees e    ";

            SqlDataAdapter adapter = new SqlDataAdapter( sql_query, sql_data.connection );
            DataSet data_set = new DataSet();

            adapter.Fill( data_set, "empl" );

            DataView dv = data_set.Tables["empl"].DefaultView;

            this.cmb_employees.ItemsSource = dv;
            this.cmb_employees.DisplayMemberPath = "full_name";
            this.cmb_employees.SelectedValuePath = "id";

            this.cmb_role.Items.Add( true );
            this.cmb_role.Items.Add( false );

        }

        private void add_new_user() {

            if ( this.cmb_employees.SelectedValue == "" ) {

                this.lb_error.Content = "Employee cannot be empty";
                return;
            }

            if ( this.txtb_login.Text == "" ) {

                this.lb_error.Content = "Login cannot be empty";
                return;
            }

            if ( this.txtb_password.Text == "" ) {

                this.lb_error.Content = "Password cannot be empty";
                return;
            }

            if ( this.cmb_role.SelectedValue == "" ) {

                this.lb_error.Content = "Role cannot be empty";
                return;
            }

            string sql_query = $@"
                
                declare @login nvarchar( 50 )
                
                select @login = u.login from dbo.Users u where u.login = '{ this.txtb_login.Text }'
                
                if( @login is null )
                    insert into dbo.Users values( { Convert.ToInt32( this.cmb_employees.SelectedValue ) }, '{ this.txtb_login.Text }', '{ this.txtb_password.Text }', { ( ( bool )this.cmb_role.SelectedValue == true ? 1 : 0 ) } )
                else
                    print 'login already exists'
            ";

            SqlCommand cmd = new SqlCommand( sql_query, sql_data.connection );

            string msg = "";

            sql_data.connection.InfoMessage += delegate( object sender, SqlInfoMessageEventArgs e ) {
                msg = e.Message;
            };
            cmd.ExecuteNonQuery();

            if( msg != "" ) {
                this.lb_error.Content = msg;
                return;
            }

            this.Close();

        }
    }
}
