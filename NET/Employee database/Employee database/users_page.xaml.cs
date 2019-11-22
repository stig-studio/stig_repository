using Employee_database.modeles;
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
    /// Логика взаимодействия для users_page.xaml
    /// </summary>
    public partial class users_page : Window {

        private string sql_query;
        private SqlDataAdapter data_adapter;

        public users_page() {
            InitializeComponent();
        }

        private void Window_Loaded( object sender, RoutedEventArgs e ) {

            update_users();

        }

        private void update_users() {

            dg_users.ItemsSource = null;
            sql_data.data_set_users = new DataSet();

            sql_data.data_set_users.Clear();

            sql_query = $@"
                
                select
                    u.id,
                    u.employee_id,
                    u.login,
                    u.password,
                    u.is_admin
                from dbo.Users u
                
            ";

            data_adapter = new SqlDataAdapter( sql_query, sql_data.connection );
            data_adapter.Fill( sql_data.data_set_users, "Users" );

            DataView dv = sql_data.data_set_users.Tables["Users"].DefaultView;

            dg_users.ItemsSource = dv;
        }

        private void btn_add_Click( object sender, RoutedEventArgs e ) {

            if ( MessageBox.Show( "Do you really want to save data?", "Saved", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes ) {

                data_adapter.Fill( sql_data.data_set_users, "Users" );
                data_adapter.UpdateCommand = new SqlCommandBuilder( data_adapter ).GetUpdateCommand();
                data_adapter.Update( sql_data.data_set_users.Tables["Users"] );

                update_users();

            }
            else return;
        }

        private void btn_new_Click(object sender, RoutedEventArgs e) {

            add_user_page usr_page = new add_user_page();
            usr_page.ShowDialog();
            update_users();
        }
    }
}
