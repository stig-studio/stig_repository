using Employees_database.modules;
using System;
using System.Collections.Generic;
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
using System.Drawing;
using System.IO;
using Employee_database;
using System.Data;
using System.Windows.Threading;

namespace Employees_database {

    /// <summary>
    /// Логика взаимодействия для main_page.xaml
    /// </summary>
    public partial class main_page : Window {

        private DispatcherTimer timer;

        public main_page() {
            InitializeComponent();
        }

        public main_page( int employee_id, int is_admin = 0 ) {

            sql_data.data_set.Clear();

            sql_data.data_set_time_tracking = new DataSet();

            string sql_query = $@"
            
            select
                e.id,
                e.last_name,
                e.first_name,
                e.patronymic_name,
                e.birthday,
                e.position,
                e.employment_date,
                e.dismissal_date,
                e.order_number,
                e.photo,
                e.address,
                e.phone_number
            from dbo.Employees e
            where
                e.id = { employee_id }  ";

            SqlDataAdapter data_adapter = new SqlDataAdapter( sql_query, sql_data.connection );
            data_adapter.Fill( sql_data.data_set, "employee" );

            sql_data.curr_employee = new Employee();
            sql_data.curr_employee.id = Convert.ToInt32(sql_data.data_set.Tables["employee"].Rows[0]["id"]);
            sql_data.curr_employee.last_name = sql_data.data_set.Tables["employee"].Rows[0]["last_name"].ToString();
            sql_data.curr_employee.first_name = sql_data.data_set.Tables["employee"].Rows[0]["first_name"].ToString();
            sql_data.curr_employee.patronymic_name = sql_data.data_set.Tables["employee"].Rows[0]["patronymic_name"].ToString();
            sql_data.curr_employee.birthday = Convert.ToDateTime( sql_data.data_set.Tables["employee"].Rows[0]["birthday"] );
            sql_data.curr_employee.position = sql_data.data_set.Tables["employee"].Rows[0]["position"].ToString();
            sql_data.curr_employee.employment_date = Convert.ToDateTime( sql_data.data_set.Tables["employee"].Rows[0]["employment_date"] );

            string dismissal_date = sql_data.data_set.Tables["employee"].Rows[0]["dismissal_date"].ToString();
            sql_data.curr_employee.dismissal_date = Convert.ToDateTime( ( dismissal_date != "" )? dismissal_date : DateTime.MinValue.ToString() );

            sql_data.curr_employee.order_number = sql_data.data_set.Tables["employee"].Rows[0]["order_number"].ToString();

            sql_data.curr_employee.photo = sql_data.data_set.Tables["employee"].Rows[0].Field<byte[]>( "photo" );
            sql_data.curr_employee.address = sql_data.data_set.Tables["employee"].Rows[0]["address"].ToString();
            sql_data.curr_employee.phone_number = sql_data.data_set.Tables["employee"].Rows[0]["phone_number"].ToString();
            sql_data.curr_employee.role_is_admin = Convert.ToBoolean( is_admin );

            InitializeComponent();
        }

        private void Window_Loaded( object sender, RoutedEventArgs e ) {

            this.last_name.Content = sql_data.curr_employee.last_name;
            this.first_name.Content = sql_data.curr_employee.first_name;
            this.patronymic_name.Content = sql_data.curr_employee.patronymic_name;
            this.birthday.Content = sql_data.curr_employee.birthday.ToShortDateString();
            this.position.Content = sql_data.curr_employee.position;
            this.employment_date.Content = sql_data.curr_employee.employment_date.ToShortDateString();
            this.dismissal_date.Content = ( sql_data.curr_employee.dismissal_date.ToShortDateString() != DateTime.MinValue.ToShortDateString() ) ? sql_data.curr_employee.dismissal_date.ToShortDateString() : "";
            this.order_number.Content = sql_data.curr_employee.order_number;

            if( sql_data.curr_employee.photo != null ) {

                var image = new BitmapImage();

                using( MemoryStream ms = new MemoryStream( sql_data.curr_employee.photo ) ) {

                    var bitmap_image = new BitmapImage();

                    bitmap_image.BeginInit();
                    bitmap_image.StreamSource = ms;
                    bitmap_image.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap_image.EndInit();

                    this.photo.Source = bitmap_image;
                }
            }

            this.address.Content = sql_data.curr_employee.address;
            this.phone_number.Content = sql_data.curr_employee.phone_number;

            this.btn_users.Visibility = ( sql_data.curr_employee.role_is_admin == true )? Visibility.Visible : Visibility.Hidden;

            update_time_tracking();

            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan( 0, 0, 10 );
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick( object sender, EventArgs e ) {
            update_time_tracking();
        }

        private void update_time_tracking() {

            sql_data.data_set_time_tracking.Clear();

            string sql_query = $@"
            
            select
                tt.id code,
                tt.employee_id,
                ( e.last_name + ' ' + e.first_name + ' ' + e.patronymic_name ) employee_full_name,
                tt.arrival,
                tt.leaving
            from dbo.Time_tracking tt
            inner join
                dbo.Employees e on e.id = tt.employee_id
            order by
                tt.id desc  ";

            SqlDataAdapter data_adapter = new SqlDataAdapter( sql_query, sql_data.connection );
            data_adapter.Fill( sql_data.data_set_time_tracking, "time_tracking" );

            List<TimeTracking> source = (
                
                from row in sql_data.data_set_time_tracking.Tables["time_tracking"].AsEnumerable()

                select new TimeTracking {
                    code = ( int )row["code"],
                    employee_id = ( int )row["employee_id"],
                    employee_full_name = row["employee_full_name"].ToString(),
                    arrival = row["arrival"].ToString(),
                    leaving = row["leaving"].ToString()
                } ).ToList();

            dg_ttracking.ItemsSource = source;
        }
        
        private void Window_Closed( object sender, EventArgs e ) {

            string sql_query = $@"
            
            declare @time_tr int
	        set @time_tr = ( select tt.id from dbo.Time_tracking tt where tt.employee_id = { sql_data.curr_employee.id } and cast( tt.arrival as date ) = cast( getdate() as date ) )
            
            if ( @time_tr is not null )
            begin
                update dbo.Time_tracking
                set
                    leaving = getdate()
                where
                    id = @time_tr
            end

            ";

            SqlCommand cmd = new SqlCommand( sql_query, sql_data.connection );

            try {
                cmd.ExecuteNonQuery();
            }
            catch ( Exception ex ) {
                MessageBox.Show( ex.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error );
            }
            finally {
                sql_data.connection.Close();
            }
        }

        private void btn_users_Click( object sender, RoutedEventArgs e ) {

            users_page usr = new users_page();
            usr.Show();
        }

        private void btn_employees_Click( object sender, RoutedEventArgs e ) {

            empl_page e_p = new empl_page();
            e_p.Show();
        }
    }
}