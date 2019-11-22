using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dz_2_1 {

    class City {

        public string name { get; set; }
        public string photo { get; set; }

        public City() {

            name = "";
            photo = "";
        }

        public City( string name, string photo ) {

            this.name = name;
            this.photo = photo;
        }

        public override string ToString() { return this.name; }

    }
}