using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace market {

    static class exchange {

        public static product prod { get; set; }

        static exchange() {
            prod = new product();
        }
    }
}