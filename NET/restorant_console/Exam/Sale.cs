using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace Exam {

    class Sale {

        Restaurant rest { get; set; }
        DateTime dt_sale { get; set; }
        private List<Dish> list { get; set; }

        public Sale( Restaurant rest ) {

            this.rest = rest;
            this.dt_sale = DateTime.MinValue;
            this.list = new List<Dish>();
        }

        public void add_dish( Dish d, int quantity ) {

            d.price *= quantity;

            for ( int i = 0; i < this.list.Count(); i++ ) {
                if (this.list[i].name == d.name) {
                    this.list[i] += d;
                    return;
                }
            }
            this.list.Add( d );
        }

        public double sum_sale() {

            double sum = 0.0;

            foreach ( Dish item in this.list ) {
                sum += item.price;
            }

            return sum;
        }

        public void get_bill() {

            this.dt_sale = DateTime.Now;

            Console.WriteLine("-----------------------------------------");

            Console.WriteLine( $"     -- {this.rest.name} --" );
            Console.WriteLine( this.rest.address );
            Console.WriteLine( this.rest.phone );

            Console.WriteLine( "-----------------------------------------" );

            foreach ( Dish item in this.list ) {
                Console.WriteLine( item.ToTable() );
                Console.WriteLine("-----------------------------------------");
            }
            Console.WriteLine( $"Сумма: {this.sum_sale()}" );
            Console.WriteLine( this.dt_sale.ToString() );

            if( !File.Exists( this.rest.name.ToString() + "_sales.txt" ) ) {
                using ( FileStream stream = File.Create( this.rest.name.ToString() + "_sales.txt" ) ) {
                    using ( StreamWriter str_wr = new StreamWriter( stream, Encoding.UTF8 ) ) {

                        str_wr.WriteLine("-----------------------------------------");

                        str_wr.WriteLine( this.rest.name );
                        str_wr.WriteLine( this.rest.address );
                        str_wr.WriteLine( this.rest.phone );
                        str_wr.WriteLine( this.rest.address );

                        str_wr.WriteLine("-----------------------------------------");

                        foreach ( Dish item in this.list ) {
                            str_wr.WriteLine( item.ToTable() );
                            str_wr.WriteLine("-----------------------------------------");
                        }
                        str_wr.WriteLine( $"Сумма: {this.sum_sale()}" );
                        str_wr.WriteLine( this.dt_sale.ToString() );

                        str_wr.Close();
                    }
                }
            }
            else {
                using ( FileStream stream = File.Open( this.rest.name.ToString() + "_sales.txt", FileMode.Append ) ) {
                    using ( StreamWriter str_wr = new StreamWriter( stream, Encoding.UTF8 ) ) {

                        str_wr.WriteLine("-----------------------------------------");

                        str_wr.WriteLine( this.rest.name );
                        str_wr.WriteLine( this.rest.address );
                        str_wr.WriteLine( this.rest.phone );
                        str_wr.WriteLine( this.rest.address );

                        str_wr.WriteLine("-----------------------------------------");

                        foreach ( Dish item in this.list ) {
                            str_wr.WriteLine( item.ToTable() );
                            str_wr.WriteLine("-----------------------------------------");
                        }
                        str_wr.WriteLine( $"Сумма: {this.sum_sale()}" );
                        str_wr.WriteLine( this.dt_sale.ToString() );

                        str_wr.Close();
                    }
                }
            }

            this.list.Clear();

            Console.ReadLine();
        }
    }
}