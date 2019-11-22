using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml.Serialization;
using System.IO;

namespace Exam {

    class Program {

        static void Main( string[] args ) {

            Restaurant vip1 = new vip_restaurant( "Стафилье", "г.Харьков, пр.Науки 66-Б", "+380 96 755 7550" );
            Restaurant vip2 = new vip_restaurant( "Ресторан Чехов", "г.Харьков, ул.Сумская 84/2", "+380 68 715 0708" );
            Restaurant vip3 = new vip_restaurant( "Пушка", "г.Харьков, ул.Пушкинская 31", "+380 67 542 5505" );
            Restaurant vip4 = new vip_restaurant( "Nikas Restaurant", "г.Харьков, ул.Университетская 2", "+380 67 000 1114" );
            Restaurant vip5 = new vip_restaurant( "Наша Дача", "г.Харьков, ул.Батумская 4а", "+380 50 108 5870" );

            Restaurant std1 = new standard_restaurant( "Шато", "г.Харьков, ул.Рымарская 30", "+380 57 705 6087" );
            Restaurant std2 = new standard_restaurant( "Фамилия", "г.Харьков, ул.Скрыпника 14а", "+380 95 455 9396" );
            Restaurant std3 = new standard_restaurant( "Итальянский ресторан Osteria Il Tartufo", "г.Харьков, ул.Культуры 20в", "+380 57 702 0703" );
            Restaurant std4 = new standard_restaurant( "Дубровский", "г.Харьков, ул.Кромская 75а", "+380 67 811 0202" );
            Restaurant std5 = new standard_restaurant( "Albatross", "г.Харьков, пр.Академика Курчатова 1а", "+380 67 811 0202" );

            Restaurant sb1 = new snack_bar( "Barsalata", "г.Харьков, ул.Героев Труда 7", "+380 95 850 4555" );
            Restaurant sb2 = new snack_bar( "ALTBIER BEER STORE", "г.Харьков, пр.Людвига Свободы 43", "+380 99 111 2345" );
            Restaurant sb3 = new snack_bar( "Маринад", "г.Харьков, ул.Мироносицкая 94/3", "+380 95 841 5333" );
            Restaurant sb4 = new snack_bar( "Katrin", "г.Харьков, ул.Елизарова 13", "+380 57 372 5054" );
            Restaurant sb5 = new snack_bar( "Электрон", "г.Харьков, ул.Маршала Бажанова 28", "+380 57 706 4272" );

            Restaurant_chain chain = new Restaurant_chain();

            chain.add( vip1 );
            chain.add( vip2 );
            chain.add( vip3 );
            chain.add( vip4 );
            chain.add( vip5 );
            chain.add( std1 );
            chain.add( std2 );
            chain.add( std3 );
            chain.add( std4 );
            chain.add( std5 );
            chain.add( sb1 );
            chain.add( sb2 );
            chain.add( sb3 );
            chain.add( sb4 );
            chain.add( sb5 );

            menu( chain );

        }

        private static void menu ( Restaurant_chain chain ) {

            while( true ) {

                int choose = -1;

                Console.Clear();

                Console.WriteLine( "1 - просмотр списка ресторанов" );
                Console.WriteLine( "2 - поиск ресторана" );
                Console.WriteLine( "3 - добавить новый ресторан" );
                Console.WriteLine( "4 - удалить ресторан" );
                Console.WriteLine( "0 - выход" );

                Console.Write( ">" );
                choose = Convert.ToInt32( Console.ReadLine() );

                if( choose > -1 && choose < 5 ) {

                    if ( choose == 0 ) break;
                    else if ( choose == 1 ) {
                        Console.Clear();
                        chain.print();
                    }
                    else if ( choose == 2 ) {
                        Console.Clear();
                        Console.WriteLine( "Введите название заведения или адрес:" );
                        Console.Write( ">" );
                        chain.find( Console.ReadLine() );
                    }
                    else if( choose == 3 ) {
                        chain.add_new();
                    }
                    else if( choose == 4 ) {
                        Console.Clear();
                        chain.delete_restaurant();
                    }
                }
                Console.ReadLine();
            }
        }
    }
}