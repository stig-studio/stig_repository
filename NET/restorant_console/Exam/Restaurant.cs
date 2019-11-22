using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace Exam {

    abstract class Restaurant {

        public string name { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        protected List<Dish> morning_menu { get; set; }
        protected List<Dish> day_menu { get; set; }
        protected List<Dish> evening_menu { get; set; }

        public Restaurant( string name, string address, string phone ) {

            this.name = name;
            this.address = address;
            this.phone = phone;
            this.morning_menu = new List<Dish>();
            this.day_menu = new List<Dish>();
            this.evening_menu = new List<Dish>();
        }

        public abstract void service();     // ------------------------------------------------- Обслуживание клиента

        public void save_menu() {  // ------------------------------------------------- Сохранение меню в xml

            XmlSerializer xml = new XmlSerializer(typeof(List<Dish>));

            try {

                int menu = Convert.ToInt32( Console.ReadLine() );

                if( this.morning_menu.Count() > 0 )
                    using ( FileStream stream = File.Create("morning_menu.xml")) { xml.Serialize(stream, this.morning_menu); }
                if( this.day_menu.Count() > 0 )
                    using ( FileStream stream = File.Create("day_menu.xml")) { xml.Serialize(stream, this.day_menu); }
                if( this.evening_menu.Count() > 0 )
                    using ( FileStream stream = File.Create("evening_menu.xml")) { xml.Serialize(stream, this.evening_menu); }
                
                Console.WriteLine( "Меню сохранено!" );
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        public abstract void load_menu();   // ------------------------------------------------- Загрузка меню с файла xml

        public void get_info() {            // ------------------------------------------------- печать информации о ресторане
            Console.WriteLine( $"Название: {this.name}\n   Адрес: {this.address}\n Телефон: {this.phone}" );
        }

        public abstract void print_menu();
    }
}