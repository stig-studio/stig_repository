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

namespace Shop {

    public partial class FormUpdate : Form {

        private SqlConnection connection;
        private string table_name;
        private DataSet data_set;
        private int id;

        public FormUpdate() {
            InitializeComponent();
        }

        public FormUpdate( int id, string table_name ): this() {

            connection = new SqlConnection( ConfigurationManager.ConnectionStrings["connectStr"].ConnectionString );
            data_set = new DataSet();

            this.id = id;
            this.table_name = table_name;

            if ( ( table_name == "Customers" ) || ( table_name == "Sellers" ) ) {

                // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

                SqlCommand cmd = new SqlCommand( $"select last_name, first_name from dbo.{table_name} where id = {id}", connection );
                SqlDataAdapter adapter = new SqlDataAdapter( cmd );

                // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

                data_set.Clear();
                adapter.Fill( data_set, table_name );

                // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

                panel_full_name.Visible = true;

                // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

                txtb_last_name.Text = data_set.Tables[table_name].Rows[0]["last_name"].ToString();
                txtb_first_name.Text = data_set.Tables[table_name].Rows[0]["first_name"].ToString();

                // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
            }
            else if( table_name == "Sales" ) {

                SqlCommand cmd = new SqlCommand( $@"

                select
                    s.customer_id,
                    ( c.last_name + ' ' + c.first_name ) customer,
                    s.seller_id,
                    ( sr.last_name + ' ' + sr.first_name ) seller,
                    s.sum_sale,
                    s.date_sale
                from dbo.Sales s
                inner join
                    dbo.Customers c on c.id = s.customer_id
                inner join
                    dbo.Sellers sr on sr.id = s.seller_id
                where s.id = {id}

                ", connection );

                // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

                data_set.Clear();
                SqlDataAdapter adapter = new SqlDataAdapter( cmd );
                adapter.Fill( data_set, table_name );

                // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

                panel_sale.Location = new Point( panel_full_name.Location.X, panel_full_name.Location.Y );
                panel_sale.Visible = true;

                // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

                SqlCommand cmd_customers = new SqlCommand( $@"select c.id, ( c.last_name + ' ' + c.first_name ) full_name from dbo.Customers c", connection );
                SqlDataAdapter adapter_customer = new SqlDataAdapter( cmd_customers );
                adapter_customer.Fill( data_set, "Customers" );

                // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

                SqlCommand cmd_sellers = new SqlCommand( $@"select sr.id, ( sr.last_name + ' ' + sr.first_name ) full_name from dbo.Sellers sr", connection );
                SqlDataAdapter adapter_seller = new SqlDataAdapter( cmd_sellers );
                adapter_seller.Fill( data_set, "Sellers" );

                // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

                cmb_customers.DataSource = data_set.Tables["Customers"];
                cmb_customers.DisplayMember = "full_name";
                cmb_customers.ValueMember = "id";
                cmb_customers.SelectedIndex = cmb_customers.FindString( data_set.Tables["Sales"].Rows[0]["customer"].ToString() );
                
                // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

                cmb_sellers.DataSource = data_set.Tables["Sellers"];
                cmb_sellers.DisplayMember = "full_name";
                cmb_sellers.ValueMember = "id";
                cmb_sellers.SelectedIndex = cmb_sellers.FindString( data_set.Tables[table_name].Rows[0]["seller"].ToString() );
                
                // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

                nud_sum_sale.Value = Convert.ToDecimal( data_set.Tables[table_name].Rows[0]["sum_sale"] );
                dtp_sale.Value = DateTime.Parse( data_set.Tables[table_name].Rows[0]["date_sale"].ToString() );

                // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
            }
        }

        private void btn_update_item_Click( object sender, EventArgs e ) {

            // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

            SqlCommand cmd = null;

            try {

                if( ( table_name == "Customers" ) || ( table_name == "Sellers" ) ) {

                    cmd = new SqlCommand( $@"

                    update dbo.{table_name}
                    set
                        last_name = '{txtb_last_name.Text}',
                        first_name = '{txtb_first_name.Text}'
                    where id = {id}

                    ", connection );
                
                }
                else if( table_name =="Sales" ) {

                    cmd = new SqlCommand( $@"

                    update dbo.{table_name}
                    set
                        customer_id = {Convert.ToInt32( cmb_customers.SelectedValue )},
                        seller_id   = {Convert.ToInt32( cmb_sellers.SelectedValue )},
                        sum_sale    = {nud_sum_sale.Value.ToString().Replace( ",", "." )},
                        date_sale   = '{dtp_sale.Value.ToString( "yyyy-MM-dd" )}'
                    where id = {id}

                    ", connection );
                }

                connection.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show( "Данные обновлены", "shop", MessageBoxButtons.OK, MessageBoxIcon.Information );
            }
            catch ( Exception ex ) {
                MessageBox.Show( ex.Message, "shop", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
            finally {
                connection.Close();
            }

            // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
        }
    }
}