using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace market {

    class sale_obj {

        public int id { get; set; }
        public string name { get; set; }
        public int count { get; set; }
        public double price { get; set; }
        public double sum { get; set; }

        public sale_obj() {

            id = 0;
            name = "";
            count = 0;
            price = 0.0;
            sum = 0.0;
            
        }

        public sale_obj( int _id, string _name, int _count, double _price, double _sum ) {

            id = _id;
            name = _name;
            count =_count;
            price = _price;
            sum = _sum;

        }

    }
}