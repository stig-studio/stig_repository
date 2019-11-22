using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using Employees_database.modules;
using System.Data.SqlClient;
using System.Data;

namespace Employee_database {

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        public MainWindow() {
            InitializeComponent();
        }

        private void btn_sign_in_Click( object sender, RoutedEventArgs e ) {
            sign_in();
        }

        private void sign_in() {

            if( txtb_login.Text == "" ) {
                lbl_msg.Content = "login cannot be empty";
                return;
            }

            if( txtb_pass.Password == "" ) {
                lbl_msg.Content = "Password cannot be empty";
                return;
            }

            sql_data.connection.Close();

            sql_data.connection.Open();

            string sql_query = $@"

                declare @login nvarchar( 50 )
                declare @pass nvarchar( 50 )
                declare @empl int
                declare @is_admin int

                select @login = u.login from dbo.Users u where u.login = '{ txtb_login.Text }'

                if( @login is not null )
                begin
	                select
		                @empl = u.employee_id, @is_admin = u.is_admin, @pass = u.password
	                from dbo.Users u
	                where u.login = @login and u.password = '{ txtb_pass.Password }'

                    if( @pass is null ) print 'wrong password'

                end
                else
	                print 'wrong login'

                if( @empl is not null and @pass is not null )
                begin
	
	                declare @time_tr int
	                set @time_tr = ( select tt.id from dbo.Time_tracking tt where tt.employee_id = @empl and cast( tt.arrival as date ) = cast( getdate() as date ) )

	                if ( @time_tr is null )
                        insert into dbo.Time_tracking values( @empl, getdate(), null )
                    
                end
                
                select @empl employee_id, @is_admin is_admin ";

            SqlCommand cmd = new SqlCommand( sql_query, sql_data.connection );
            SqlDataAdapter data_adapter = new SqlDataAdapter( cmd );

            string msg = "";

            sql_data.connection.InfoMessage += delegate ( object sender, SqlInfoMessageEventArgs e ) { msg = e.Message; };
            sql_data.data_set = new System.Data.DataSet();


            data_adapter.Fill( sql_data.data_set, "user_login" );


            if ( msg != "" )  { lbl_msg.Content = msg; return; }

            Employees_database.main_page m_page = new Employees_database.main_page( Convert.ToInt32( sql_data.data_set.Tables["user_login"].Rows[0]["employee_id"] ), Convert.ToInt32( sql_data.data_set.Tables["user_login"].Rows[0]["is_admin"] ) );
            m_page.Show();

            this.Close();
        }

        private void Window_Loaded( object sender, RoutedEventArgs e ) {
            txtb_login.Focus();
        }

        private void btn_close_Click( object sender, RoutedEventArgs e ) {
            this.Close();
        }
    }
}