using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Data.SqlClient;
using System.Configuration;
using Employees_database.modules;
using System.Windows.Threading;
using System.Security.Permissions;

namespace Employee_database {

    /// <summary>
    /// Логика взаимодействия для start_page.xaml
    /// </summary>
    public partial class start_page : Window {

        public start_page() {
            InitializeComponent();
        }

        DispatcherTimer t;

        private void Window_Loaded( object sender, RoutedEventArgs e ) {

            this.Show();

            t = new DispatcherTimer();
            t.Tick += new EventHandler( t_tick );
            t.Interval = new TimeSpan( 0, 0, 2 );
            t.Start();
        }

        private void t_tick( object sender, EventArgs e ) {
            when_opening();
        }

        private void when_opening() {

            t.Stop();

            sql_data.connection = new SqlConnection( ConfigurationManager.ConnectionStrings["connectStr"].ConnectionString );

            lbl_info.Content = checked_data_base();

            DoEvents();

            string msg = checked_table();

            if( msg != "" ) {

                var msg_arr = msg.Split( '\n' );

                for( int i = 0; i < msg_arr.Length; i++ ) {
                    lbl_info.Content = msg_arr[i];
                    DoEvents();
                }
            }

            MainWindow authorization = new MainWindow();
            authorization.Show();

            this.Close();

        }

        [SecurityPermissionAttribute( SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode )]
        public void DoEvents() {

            DispatcherFrame frame = new DispatcherFrame();
            Dispatcher.CurrentDispatcher.BeginInvoke( DispatcherPriority.Background, new DispatcherOperationCallback( ExitFrame ), frame );
            Dispatcher.PushFrame( frame );
        }

        public object ExitFrame( object f ) {

            ( ( DispatcherFrame ) f ).Continue = false;
            return null;
        }

        private string checked_data_base() {

            SqlConnection connection = new SqlConnection( "Server=localhost;Integrated security=SSPI;database=master" );

            try {

                string txt = @"

                    if db_id( 'Employees_db' ) is null
                    begin
                        create database Employees_db
                        print 'database created'
                    end
                
                ";

                SqlCommand cmd = new SqlCommand( txt, connection);

                connection.Open();

                string msg = "";

                connection.InfoMessage += delegate( object sender, SqlInfoMessageEventArgs e ) {
                    msg = e.Message;
                };
                cmd.ExecuteNonQuery();

                return msg;
            }
            catch ( Exception ex ) {
                return ex.Message;
            }
            finally {
                connection.Close();
            }
        }

        private string checked_table() {

            string txt = $@"
            
            -- + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + 
            
            if object_id( N'Employees' ) is null
            begin
	            create table Employees (

                    id int identity primary key not null,
                    last_name nvarchar( 50 ) not null,
                    first_name nvarchar( 50 ) not null,
                    patronymic_name nvarchar( 50 ) not null,
                    birthday date not null,
                    position nvarchar( 50 ) not null,
                    employment_date date not null,
                    dismissal_date date,
                    order_number nvarchar( 50 ),
                    photo varbinary( max ),
                    address nvarchar( 50 ),
                    phone_number nvarchar( 20 )

                )
                
                print 'table Employees created'
                
                insert into dbo.Employees values( 'admin', '', '', '{ DateTime.MinValue.ToString( "yyyy-MM-dd" ) }', 'sysadmin', '{ DateTime.MinValue.ToString( "yyyy-MM-dd" ) }', null, '', null, '', '' )
                
            end
            
            -- + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + 
            
            if object_id( N'Time_tracking' ) is null
            begin
                create table Time_tracking (

                    id int identity primary key not null,
                    employee_id int foreign key references Employees( id ) not null,
                    arrival datetime not null,
                    leaving datetime
                )

                print 'table Time_tracking created'

            end

            -- + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + 

            if object_id( N'Users' ) is null
            begin
                create table Users (

                    id int identity primary key not null,
                    employee_id int foreign key references Employees( id ),
                    login nvarchar( 50 ) not null,
                    password nvarchar( 50 ) not null,
                    is_admin bit not null
                )
                
                print 'table Users created'
                
                insert into dbo.Users values( 1, 'admin', 'admin', 1 )
                
            end

            -- + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + 
            ";

            SqlCommand cmd = new SqlCommand( txt, sql_data.connection );

            try {

                string msg = "";

                sql_data.connection.Open();

                sql_data.connection.InfoMessage += delegate( object sender, SqlInfoMessageEventArgs e ) {
                    msg = e.Message;
                };

                cmd.ExecuteNonQuery();

                return msg;
            }
            catch ( Exception ex ) {
                return ex.Message;
            }
            finally {
                sql_data.connection.Close();
            }
        }
    }
}