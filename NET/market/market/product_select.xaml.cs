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
using System.Windows.Shapes;

namespace market {

    /// <summary>
    /// Логика взаимодействия для product_select.xaml
    /// </summary>

    public partial class product_select : Window {

        public product_select() {
            InitializeComponent();

            lbl_prod_name.Content = exchange.prod.name;
            lbl_prod_price.Content = exchange.prod.price;
            lbl_prod_balance.Content = exchange.prod.balance;

        }

        private void btn_ok_Click( object sender, RoutedEventArgs e ) {

            if( Convert.ToInt32( txt_b_count.Text ) > 0 && Convert.ToInt32( txt_b_count.Text ) <= exchange.prod.balance ) {
                exchange.prod.count = Convert.ToInt32( txt_b_count.Text );
                this.Close();
            }
            else {
                MessageBox.Show( "Не допустимое количество", "error", MessageBoxButton.OK, MessageBoxImage.Error );
            }
        }
    }
}
