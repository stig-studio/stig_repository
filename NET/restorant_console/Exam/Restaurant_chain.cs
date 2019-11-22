using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace Exam {

    class Restaurant_chain {

        private List<Restaurant> list { get; set; }

        public Restaurant_chain() {
            this.list = new List<Restaurant>();
        }

        public void add( Restaurant r ) {
            this.list.Add( r );
        }


        public void print () {

            int quantity = 0;
            int number = 1;

            foreach ( Restaurant item in this.list) {
                quantity++;
                Console.WriteLine( $"#{number++}" );
                item.get_info();
                Console.WriteLine( "-------------------------------------------------------------" );
            }
            if (quantity == 0) Console.WriteLine("Не одного заведения не найдено ...");
            else {

                int choose = -1;

                Console.WriteLine("1 - Выбрать заведение");
                Console.WriteLine("0 - Выход");
                Console.Write(">");

                choose = Convert.ToInt32(Console.ReadLine());

                if (choose == 1)
                {
                    Console.Write("\nВведите номер заведения:\n>");
                    int res = Convert.ToInt32(Console.ReadLine());

                    if (res > 0 && res <= this.list.Count()) this.list[res - 1].service();
                }
            }
        }

        public void delete_restaurant() {

            int quantity = 0;
            int number = 1;

            foreach (Restaurant item in this.list) {

                quantity++;
                Console.WriteLine($"#{number++}");
                item.get_info();
                Console.WriteLine("-------------------------------------------------------------");
            }
            if (quantity == 0) Console.WriteLine("Не одного заведения не найдено ...");
            else {

                int choose = -1;

                Console.WriteLine("1 - Выбрать заведение");
                Console.WriteLine("0 - Выход");
                Console.Write(">");

                choose = Convert.ToInt32(Console.ReadLine());

                if (choose == 1) {

                    Console.Write("\nВведите номер заведения:\n>");
                    int res = Convert.ToInt32(Console.ReadLine());
                    if (res > 0 && res <= this.list.Count()) this.list.RemoveAt( res - 1 );
                }
            }
        }
        
        public void find( string text ) {

            int quantity = 0;
            int number = 1;

            SortedList<int, Restaurant> tmp = new SortedList<int, Restaurant>();

            foreach ( Restaurant item in this.list ) {

                if( item.name.ToUpper().IndexOf( text.ToUpper() ) != -1 || item.address.ToUpper().IndexOf( text.ToUpper() ) != -1 ) {
                    quantity++;
                    Console.WriteLine( $"\n#{number}" );
                    item.get_info();
                    Console.WriteLine( "-------------------------------------------------------------" );
                    tmp.Add( number, item );
                }
                number++;
            }

            if (quantity == 0) Console.WriteLine("Не одного заведения не найдено ...");
            else this.select_restaurant( tmp );
        }

        public void select_restaurant( SortedList<int, Restaurant> tmp ) {

            int choose = -1;

            Console.WriteLine("\n=============================================================\n");
            Console.WriteLine("1 - Выбрать заведение");
            Console.WriteLine("0 - Выход");
            Console.Write(">");

            choose = Convert.ToInt32(Console.ReadLine());

            if (choose == 1) {
                Console.Write("\nВведите номер заведения:\n>");
                int res = Convert.ToInt32(Console.ReadLine());

                if (tmp.IndexOfKey(res) != -1) tmp[res].service();
            }
        }

        public void edit( int number ) {

            while( true ) {

                string name = "";
                string addr = "";
                string phone = "";

                int choose = -1;

                Console.WriteLine( "1 - Изменить название заведения" );
                Console.WriteLine( "2 - Изменить адрес заведения" );
                Console.WriteLine( "3 - Изменить номер телефона заведения" );
                Console.WriteLine( "0 - выход" );
                Console.Write( ">" );

                choose = Convert.ToInt32( Console.ReadLine() );

                if( choose > -1 && choose < 4 ) {

                    if( choose == 1 ) {

                        Console.Write( "Введите новое название заведения:\n>" );
                        name = Console.ReadLine();

                        if ( name != "" ) this.list[number - 1].name = name;
                        else Console.WriteLine( "Название заведения не может быть пустым ..." );
                    }
                    else if( choose == 2 ) {

                        Console.Write( "Введите новый адрес заведения:\n>" );
                        addr = Console.ReadLine();

                        if ( addr != "" ) this.list[number - 1].address = addr;
                        else Console.WriteLine( "Адрес заведения не может быть пустым ..." );
                    }
                    else if( choose == 3 ) {

                        Console.Write( "Введите новый номер телефона заведения:\n>" );
                        phone = Console.ReadLine();

                        if ( phone != "" ) this.list[number - 1].phone = phone;
                        else Console.WriteLine("Номер телефона заведения не может быть пустым ...");
                    }
                }
                Console.ReadLine();
            }
        }

        public void add_new() {

            string name = "";
            string addr = "";
            string phone = "";

            Console.Clear();

            while ( true ) {

                int ch = -1;

                Console.Clear();

                Console.WriteLine( "1 - vip-ресторан" );
                Console.WriteLine( "2 - стандартный ресторан" );
                Console.WriteLine( "3 - закусочная" );
                Console.WriteLine( "0 - отмена" );
                Console.Write( ">" );

                ch = Convert.ToInt32( Console.ReadLine() );

                if ( ch > -1 && ch < 4 ) {

                    if ( ch == 0 ) break;

                    while ( true ) {

                        Console.Clear();
                        Console.Write( "Введите название ресторана:\n>" );
                        name = Console.ReadLine();

                        if ( name != "" ) break;
                    }

                    while ( true ) {

                        Console.Clear();
                        Console.Write( "Введите адрес ресторана:\n>" );
                        addr = Console.ReadLine();

                        if ( addr != "" ) break;
                    }

                    while ( true ) {

                        Console.Clear();
                        Console.Write( "Введите номер телефона ресторана:\n>" );
                        phone = Console.ReadLine();

                        if ( phone != "" ) break;
                    }

                    if ( ch == 1 ) {
                        Restaurant tmp = new vip_restaurant( name, addr, phone );
                        this.list.Add( tmp );
                    }
                    else if ( ch == 2 ) {
                        Restaurant tmp = new standard_restaurant( name, addr, phone );
                        this.list.Add( tmp );
                    }
                    else if ( ch == 3 ) {
                        Restaurant tmp = new snack_bar( name, addr, phone );
                        this.list.Add( tmp );
                    }
                }
            }
        }
    }
}