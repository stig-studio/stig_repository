using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace market {

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window {

        DataSet data_set = new DataSet();
        DataSet data_set_sale = new DataSet();
        SqlConnection sqlConnection = new SqlConnection( @"Server=127.0.0.1;Database=market; User Id=market_select; Password=1122334455; Connection Timeout=5000" );
        SqlDataAdapter adapter = new SqlDataAdapter();
        static List<sale_obj> list = new List<sale_obj>();

        public MainWindow() {
            InitializeComponent();
            list_sale.ItemsSource = list;
        }


        private void btn_list_prod_Click( object sender, RoutedEventArgs e ) {

            data_set.Clear();

            data_grid_prod.Visibility = Visibility.Visible;

            sqlConnection.Open();

            string cmd = @"select
                            p.id [код],
                            p.name [товар],
                            p.real_price [цена],
                            p.barcode [штрих]
                            from dbo.products p";

            adapter.SelectCommand = new SqlCommand( cmd, sqlConnection );
            adapter.Fill( data_set, "products" );
            data_grid_prod.ItemsSource = data_set.Tables["products"].DefaultView;

            sqlConnection.Close();
        }

        private void Window_Loaded( object sender, RoutedEventArgs e ) {

            txt_barcode.Text = "Введите штрих-код для поиска ...";
            txt_barcode.Foreground = new SolidColorBrush( Colors.Gray );
        }

        private void txt_barcode_GotFocus( object sender, RoutedEventArgs e ) {

            txt_barcode.Foreground = new SolidColorBrush( Colors.Black );
            if ( txt_barcode.Text == "Введите штрих-код для поиска ..." ) txt_barcode.Text = "";
        }

        private void txt_barcode_LostFocus( object sender, RoutedEventArgs e ) {

            if( txt_barcode.Text == "" ) {
                    txt_barcode.Foreground = new SolidColorBrush( Colors.Gray );
                    txt_barcode.Text = "Введите штрих-код для поиска ...";
                }
        }

        private void txt_barcode_KeyDown( object sender, KeyEventArgs e ) {

            if( txt_barcode.Text.Length > 13 ) { MessageBox.Show( "Слишком длинный штрих", "Info", MessageBoxButton.OK, MessageBoxImage.Exclamation ); return; }

            if ( e.Key == Key.Enter ) {

                data_set_sale.Clear();

                sqlConnection.Open();

                string cmd = $@"select
                                p.id [id],
                                p.name [name],
                                b.count_products [balance],
                                p.real_price [price]
                                from dbo.products p
                                inner join
                                dbo.balance b on b.id_product = p.id
                                where p.barcode = cast( {txt_barcode.Text} as nvarchar( 13 ) )";

                adapter.SelectCommand = new SqlCommand( cmd, sqlConnection );
                adapter.Fill( data_set_sale, "products" );

                if( data_set_sale.Tables["products"].Select( "" ).Length > 0 ) {

                    var items = data_set_sale.Tables[0].Select();

                    foreach ( var item in items ) {
                        exchange.prod = new product( Convert.ToInt32( item["id"] ), item["name"].ToString(), Convert.ToDouble( item["price"] ), Convert.ToInt32( item["balance"] ) );
                    }

                    product_select product_Select = new product_select();
                    product_Select.ShowDialog();

                    if( exchange.prod.count > 0 ) {

                        sale_obj obj = new sale_obj( exchange.prod.id, exchange.prod.name, exchange.prod.count, exchange.prod.price, exchange.prod.count * exchange.prod.price );

                        list.Add( obj );

                        //list_sale.Items.Clear();

                        list_sale.ItemsSource = null;
                        list_sale.ItemsSource = list;
                    }
                }
                else {
                    MessageBox.Show( "Товар с таким штрих-кодом не найден", "Info", MessageBoxButton.OK, MessageBoxImage.Information );
                }
                
                sqlConnection.Close();
            }
        }

        private void btn_pay_Click( object sender, RoutedEventArgs e ) {

            if( list.Count == 0 ) {
                MessageBox.Show( "Не выбран товар для покупки!", "Info", MessageBoxButton.OK, MessageBoxImage.Information );
                return;
            }

            sqlConnection.Open();

            string cmd = $@"insert into dbo.sale values( getdate() )

                                declare @id_sale int

                                select top 1 @id_sale = s.id from dbo.sale s order by s.dt_sale desc
                                
                                ";

            foreach ( sale_obj s_obj in list ) {
                cmd += $"insert into dbo.sale_products values( @id_sale, {s_obj.id}, {s_obj.count} )\n";
            }

            SqlCommand sql_cmd = new SqlCommand( cmd, sqlConnection );

            sql_cmd.ExecuteNonQuery();

            list.Clear();
            list_sale.ItemsSource = null;
            list_sale.ItemsSource = list;

            sqlConnection.Close();

        }
    }
}