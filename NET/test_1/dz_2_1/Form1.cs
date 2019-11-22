using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace dz_2_1 {

    public partial class Form1 : Form {

        int active_continent;
        string curr_path;
        List<List<City>> list_continents;
        
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load( object sender, EventArgs e ) {

            active_continent = -1;
            curr_path = Environment.CurrentDirectory;

            List<City> list_europe = new List<City>();

            list_europe.Add(new City("Париж", curr_path + @"\image\Paris.jpg"));
            list_europe.Add(new City("Лондон", curr_path + @"\image\London.jpg"));
            list_europe.Add(new City("Рим", curr_path + @"\image\Rome.jpeg"));
            list_europe.Add(new City("Барселона", curr_path + @"\image\Barselona.jpg"));
            list_europe.Add(new City("Амстердам", curr_path + @"\image\Amsterdam.jpg"));

            List<City> list_africa = new List<City>();

            list_africa.Add(new City("Кейптаун", curr_path + @"\image\Capetown.jpg"));
            list_africa.Add(new City("Йоханнесбург", curr_path + @"\image\Johannesburg.jpg"));
            list_africa.Add(new City("Найроби", curr_path + @"\image\Nairobi.jpg"));
            list_africa.Add(new City("Аккра", curr_path + @"\image\Akkra.jpg"));

            List<City> list_asia = new List<City>();

            list_asia.Add(new City("Пекин", curr_path + @"\image\Pekin.jpg"));
            list_asia.Add(new City("Токиа", curr_path + @"\image\Tokiya.png"));
            list_asia.Add(new City("Бангок", curr_path + @"\image\Bangok.jpg"));
            list_asia.Add(new City("Шанхай", curr_path + @"\image\Shanghai.jpg"));
            list_asia.Add(new City("Мумбаи", curr_path + @"\image\Mumbai.jpg"));
            list_asia.Add(new City("Стамбул", curr_path + @"\image\Istanbul.jpg"));
            list_asia.Add(new City("Дубай", curr_path + @"\image\Dubai.jpg"));

            List<City> list_s_america = new List<City>();

            list_s_america.Add(new City("Рио-де-Жанейро", curr_path + @"\image\Rio.jpg"));
            list_s_america.Add(new City("Буэнос-Айрес", curr_path + @"\image\Buenos_Aires.jpg"));
            list_s_america.Add(new City("Сантьяго", curr_path + @"\image\Santyago.jpg"));
            list_s_america.Add(new City("Сан-Пауло", curr_path + @"\image\San-paolo.jpg"));

            List<City> list_n_america = new List<City>();

            list_n_america.Add(new City("Нью-Йорк", curr_path + @"\image\New York.jpg"));
            list_n_america.Add(new City("Лос-Анджелес", curr_path + @"\image\los_angeles.jpg"));
            list_n_america.Add(new City("Чикаго", curr_path + @"\image\Chicago.jpg"));
            list_n_america.Add(new City("Вашингтон", curr_path + @"\image\Washington.jpg"));
            list_n_america.Add(new City("Лас-Вегас", curr_path + @"\image\Las-Vegas.png"));

            List<City> list_australia = new List<City>();

            list_australia.Add(new City("Сидней", curr_path + @"\image\Sidney.jpg"));
            list_australia.Add(new City("Мельбурн", curr_path + @"\image\Melburn.jpg"));
            list_australia.Add(new City("Брисбен", curr_path + @"\image\Brisben.jpg"));
            list_australia.Add(new City("Канберра", curr_path + @"\image\Kanbera.jpg"));
            
            list_continents = new List<List<City>>();

            list_continents.Add(list_europe);
            list_continents.Add(list_africa);
            list_continents.Add(list_asia);
            list_continents.Add(list_s_america);
            list_continents.Add(list_n_america);
            list_continents.Add(list_australia);
        }

        private void rb_CheckedChanged(object sender, EventArgs e) {

            if( ( sender as RadioButton ).Checked == true ) {

                active_continent = Convert.ToInt32( (sender as RadioButton).Tag );
                cmb_city.Items.Clear();

                foreach (City item in list_continents[active_continent]) {
                    cmb_city.Items.Add(item.ToString());
                }

                cmb_city.SelectedIndex = 0;
            }
        }

        private void cmb_city_SelectedIndexChanged(object sender, EventArgs e) {
            pb.Image = Image.FromFile( list_continents[active_continent][cmb_city.SelectedIndex].photo );
        }

        private void ch_list_values_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void ch_list_values_SelectedValueChanged(object sender, EventArgs e) {

            selected_values.Items.Clear();

            foreach (var item in ch_list_values.CheckedItems) {
                selected_values.Items.Add(item);
            }
            calc();
        }

        private void calc() {

            int res = 0;

            foreach (var item in selected_values.Items) { res += Convert.ToInt32( item ); }

            lbl_msg.Visible = ( res == 50 ) ? true : false;
            
            lbl_result.Text = "Результат: " + res.ToString();
        }
    }
}