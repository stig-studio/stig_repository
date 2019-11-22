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

    public partial class FormTable : Form {

        private SqlConnection connection;
        private string table_name;
        private DataSet data_set;

        public FormTable() {
            InitializeComponent();
        }

        public FormTable( string table ): this() {

            lbl_table.Text = table;
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connectStr"].ConnectionString);
            data_set = new DataSet();

            try {

                refresh_data();

                if( ( table == "ПОКУПАТЕЛИ" ) || ( table == "ПРОДАВЦЫ" ) ) {

                    panel_full_name.Visible = true;
                }
                else if( table == "ПРОДАЖИ" ) {

                    panel_sale.Location = new Point( panel_full_name.Location.X, panel_full_name.Location.Y );
                    panel_sale.Visible = true;

                    SqlCommand cmd_customer = new SqlCommand( "select c.id, ( c.last_name + ' ' + c.first_name ) full_name from dbo.Customers c", connection );
                    SqlDataAdapter adapter_customer = new SqlDataAdapter( cmd_customer );

                    adapter_customer.Fill( data_set, "Customers" );

                    cmb_customers.DataSource = data_set.Tables["Customers"];
                    cmb_customers.DisplayMember = "full_name";
                    cmb_customers.ValueMember = "id";

                    SqlCommand cmd_seller = new SqlCommand( "select s.id, ( s.last_name + ' ' + s.first_name ) full_name from dbo.Sellers s", connection );
                    SqlDataAdapter adapter_seller = new SqlDataAdapter( cmd_seller );
                    
                    adapter_seller.Fill( data_set, "Sellers" );

                    cmb_sellers.DataSource = data_set.Tables["Sellers"];
                    cmb_sellers.DisplayMember = "full_name";
                    cmb_sellers.ValueMember = "id";

                }
            }
            catch ( Exception ex ) {
                MessageBox.Show( ex.Message, "shop", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }

        private void btn_add( string table ) {

            SqlCommand cmd;

            try {

                if ( ( table == "Customers") || ( table == "Sellers") ) {

                    cmd = new SqlCommand( $@"insert into dbo.{table_name} values( '{txtb_last_name.Text}', '{txtb_first_name.Text}' )", connection );

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                else if( table == "Sales" ) {

                    cmd = new SqlCommand( $@"insert into dbo.Sales values(
                        {Convert.ToInt32( cmb_customers.SelectedValue )},
                        {Convert.ToInt32( cmb_sellers.SelectedValue )},
                        {nud_sum_sale.Value.ToString().Replace( ",", "." )},
                        '{dtp_sale.Value.ToString( "yyyy-MM-dd" )}'
                    )", connection );

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }

                refresh_data();
            }
            catch( Exception ex ) {

                MessageBox.Show( ex.Message, "shop", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
            finally {
                connection.Close();
            }
        }

        private void refresh_data() {

            try {

                string txt_sql = "";

                if ( ( lbl_table.Text == "ПОКУПАТЕЛИ" ) || ( lbl_table.Text == "ПРОДАВЦЫ" ) ) {

                    table_name = ( lbl_table.Text == "ПОКУПАТЕЛИ" ) ? "Customers" : "Sellers";

                    txt_sql = $@"

                    select
                        id,
                        last_name [ Фамилия ],
                        first_name [ Имя ]
                    from dbo.{table_name}";
                }
                else if ( lbl_table.Text == "ПРОДАЖИ" ) {

                    table_name = "Sales";

                    txt_sql = @"

                    select
                        s.id,
                        s.date_sale [ Дата покупки ],
                        ( c.last_name + ' ' + c.first_name ) [ Покупатель ],
                        ( sr.last_name + ' ' + sr.first_name ) [ Продавец ],
                        s.sum_sale [ Сумма покупки ]
                    from dbo.Sales s
                    inner join
                        dbo.Customers c on c.id = s.customer_id
                    inner join
                        dbo.Sellers sr on sr.id = s.seller_id

                    ";
                }

                SqlCommand cmd = new SqlCommand( txt_sql, connection );
                SqlDataAdapter adapter = new SqlDataAdapter( cmd );

                data_set.Clear();

                adapter.Fill( data_set, table_name );

                dgv_table.DataSource = data_set.Tables[table_name];
            }
            catch ( Exception ex ) {
                MessageBox.Show( ex.Message, "shop", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }

        private void btn_add_item_Click( object sender, EventArgs e ) {

            if( ( table_name == "Customers" ) || ( table_name == "Sellers" ) ) {

                if( txtb_last_name.Text == "" ) {

                    MessageBox.Show( "Не заполнено поле Фамилия", "shop", MessageBoxButtons.OK, MessageBoxIcon.Warning );
                    return;
                }

                if( txtb_first_name.Text == "" ) {

                    MessageBox.Show( "Не заполнено поле Имя", "shop", MessageBoxButtons.OK, MessageBoxIcon.Warning );
                    return;
                }
            }
            else if( table_name == "Sales" ) {

                if( Convert.ToInt32( cmb_customers.SelectedValue ) == 0 ) {

                    MessageBox.Show( "Не заполнено поле Покупатель", "shop", MessageBoxButtons.OK, MessageBoxIcon.Warning );
                    return;
                }
                else if( Convert.ToInt32( cmb_sellers.SelectedValue ) == 0 ) {

                    MessageBox.Show( "Не заполнено поле Продавец", "shop", MessageBoxButtons.OK, MessageBoxIcon.Warning );
                    return;
                }
                else if( ( dtp_sale.Value.ToString() == "" ) || ( dtp_sale.Value > DateTime.Now ) ) {

                    MessageBox.Show( "Не допустимое значение даты", "shop", MessageBoxButtons.OK, MessageBoxIcon.Warning );
                    return;
                }
                else if( Convert.ToDouble( nud_sum_sale.Value ) == 0.0 ) {

                    MessageBox.Show( "Сумма покупки не может быть 0.0", "shop", MessageBoxButtons.OK, MessageBoxIcon.Warning );
                    return;
                }
            }

            btn_add( table_name );
        }

        private void dgv_table_CellMouseDown( object sender, DataGridViewCellMouseEventArgs e ) {

            if ( e.Button == MouseButtons.Right ) {

                int pos_x = Cursor.Position.X;
                int pos_y = Cursor.Position.Y;

                context_menu.Show( pos_x, pos_y );
            }
        }

        private void update_tool_strip_Click( object sender, EventArgs e ) {

            int id = Convert.ToInt32( data_set.Tables[table_name].Rows[dgv_table.CurrentCell.RowIndex]["id"] );

            FormUpdate form_update = new FormUpdate( id, table_name );
            form_update.ShowDialog();

            refresh_data();
        }

        private void del_tool_strip_Click( object sender, EventArgs e ) {

            int id = Convert.ToInt32( data_set.Tables[table_name].Rows[dgv_table.CurrentCell.RowIndex]["id"] );

            try {

                if( MessageBox.Show( "Вы действительно хотите удалить элемент?", "shop", MessageBoxButtons.YesNo, MessageBoxIcon.Question ) == DialogResult.Yes ) {

                    SqlCommand cmd = new SqlCommand( $@"

                    delete from dbo.{table_name}
                    where id = {id}

                    ", connection ); ;

                    connection.Open();
                    cmd.ExecuteNonQuery();

                    refresh_data();
                }
                else return;
            }
            catch ( Exception ex ) {
                MessageBox.Show( ex.Message, "shop", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
            finally {
                connection.Close();
            }
        }
    }
}