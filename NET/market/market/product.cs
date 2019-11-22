using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace market {

    class product {

        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public int balance { get; set; }
        public int count { get; set; }

        public product() {

            id = 0;
            name = "";
            price = 0.0;
            balance = 0;
            count = 0;

        }

        public product( int _id, string _name, double _price, int _balance ) {

            id = _id;
            name = _name;
            price = _price;
            balance = _balance;
            count = 0;

        }
    }
}