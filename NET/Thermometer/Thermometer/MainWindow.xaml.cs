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
using System.Net;
using System.Text.RegularExpressions;
using System.IO;

namespace Thermometer
{

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window {


        public MainWindow() {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


            WebRequest request;
            request = WebRequest.Create(@"https://sinoptik.ua/погода-харьков" );
            using ( var responce = request.GetResponse() ) {

                using ( var stream = responce.GetResponseStream() )
                using ( var reader = new StreamReader( stream ) ) {

                    string data = reader.ReadToEnd();
                    
                    string curr_temp = new Regex(@"<p class=""today-temp"">(?<tempNow>[^<]+)</p>").Match(data).Groups["tempNow"].Value;
                    curr_temp = curr_temp.Replace( "&deg;C", "" );
                    therm.Value = Convert.ToInt32( curr_temp );
                }
            }
        }
    }
}