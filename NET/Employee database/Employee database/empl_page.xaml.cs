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
    /// Логика взаимодействия для empl_page.xaml
    /// </summary>
    public partial class empl_page : Window {

        private string sql_query;
        private SqlDataAdapter data_adapter;

        public empl_page() {
            InitializeComponent();
        }

        private void Window_Loaded( object sender, RoutedEventArgs e ) {

            this.dg_empl.IsReadOnly = !sql_data.curr_employee.role_is_admin;
            this.btn_add.Visibility = ( sql_data.curr_employee.role_is_admin == true ) ? Visibility.Visible : Visibility.Hidden;

            update_table();
        }

        private void update_table() {

            sql_data.data_set_emp = new DataSet();

            sql_data.data_set_emp.Clear();

            sql_query = $@"
            select
                u.id,
                u.last_name,
                u.first_name,
                u.patronymic_name,
                u.birthday,
                u.position,
                u.employment_date,
                u.dismissal_date,
                u.order_number,
                u.address,
                u.phone_number
            from dbo.Employees u    ";

            data_adapter = new SqlDataAdapter( sql_query, sql_data.connection );
            data_adapter.Fill( sql_data.data_set_emp, "Employees" );

            DataView dv = sql_data.data_set_emp.Tables["Employees"].DefaultView;

            dg_empl.ItemsSource = dv;
        }

        private void btn_add_Click( object sender, RoutedEventArgs e ) {

            add_empl_page add_page = new add_empl_page();
            add_page.ShowDialog();

            update_table();
        }
    }
}