using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Runtime.InteropServices;

namespace Shop {

    public partial class Form1 : Form {

        [DllImport( "user32.dll" )]
        private static extern int SetWindowLong( IntPtr window, int index, int value );

        [DllImport( "user32.dll" )]
        private static extern int GetWindowLong( IntPtr window, int index );

        private const int GWL_EXSTYLE = -20;
        private const int WS_EX_TOOLWINDOW = 0x00000080;

        public static void HideFromAltTab( IntPtr Handle ) {
            SetWindowLong( Handle, GWL_EXSTYLE, GetWindowLong( Handle,
                GWL_EXSTYLE) | WS_EX_TOOLWINDOW );
        }

        private SqlConnection connection;

        public Form1() {

            InitializeComponent();

            this.MouseDown += delegate {

                this.Capture = false;
                var msg = Message.Create( this.Handle, 0xa1, new IntPtr( 2 ), IntPtr.Zero );
                this.WndProc( ref msg );
            };
        }

        private void Form1_Load( object sender, EventArgs e ) {

            connection = new SqlConnection( ConfigurationManager.ConnectionStrings[ "connectStr" ].ConnectionString );

            string msg = checked_data_base();

            if( msg != "" )
                list_box_info.Items.Add( msg );

            msg = checked_table();

            if( msg != "" ) {

                var msg_arr = msg.Split( '\n' );

                for( int i = 0; i < msg_arr.Length; i++ )
                    list_box_info.Items.Add( msg_arr[i] );
            }

            auto_scroll();
        }

        private void auto_scroll() {

            list_box_info.SelectedIndex = list_box_info.Items.Count - 1;
            list_box_info.SelectedIndex = -1;
        }

        private string checked_data_base() {

            SqlConnection connection = new SqlConnection( "Server=localhost;Integrated security=SSPI;database=master" );

            try {

                string txt = @"
                if db_id( 'shop' ) is null
                begin
                    create database shop
                    print 'database created'
                end
                ";

                SqlCommand cmd = new SqlCommand( txt, connection );

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

            string txt = @"
            
            --------------------------------------------------------------------
            
            if object_id( N'Customers' ) is null
            begin
	            create table Customers (

                    id int identity primary key not null,
                    last_name nvarchar( 50 ) not null,
                    first_name nvarchar( 50 ) not null
                )
                
                print 'table Customers created'
                
            end
            
            --------------------------------------------------------------------
            
            if object_id( N'Sellers' ) is null
            begin
                create table Sellers (

                    id int identity primary key not null,
                    last_name nvarchar( 50 ) not null,
                    first_name nvarchar( 50 ) not null
                )

                print 'table Sellers created'

            end

            --------------------------------------------------------------------

            if object_id( N'Sales' ) is null
            begin
                create table Sales (

                    id int identity primary key not null,
                    customer_id int foreign key references Customers( id ),
                    seller_id int foreign key references Sellers( id ),
                    sum_sale float not null,
                    date_sale date not null
                )
                
                print 'table Sales created'
                
            end
            
            --------------------------------------------------------------------
            ";

            SqlCommand cmd = new SqlCommand( txt, connection );

            try {

                string msg = "";

                connection.Open();

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

        private void btn_close_Click( object sender, EventArgs e ) {

            this.Close();
            Application.Exit();
        }

        private void btn_maximize_Click( object sender, EventArgs e ) {
            this.WindowState = ( this.WindowState == FormWindowState.Maximized )? FormWindowState.Normal: FormWindowState.Maximized;
        }

        private void btn_minimize_Click( object sender, EventArgs e ) {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_table_Click( object sender, EventArgs e ) {

            FormTable f_table = new FormTable( ( sender as Button ).Text );
            f_table.ShowDialog();
        }

        private void btn_test_connection_Click( object sender, EventArgs e ) {

            try {
                connection.Open();
                list_box_info.Items.Add( "connection test successful" );
            }
            catch ( Exception ex ) {
                list_box_info.Items.Add( ex.Message );
            }
            finally {
                connection.Close();
                auto_scroll();
            }
        }
    }
}