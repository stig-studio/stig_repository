using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace School_magazine.models {

    public class Employee {

        public int id { get; set; }
        public string l_name { get; set; }
        public string f_name { get; set; }
        public string p_name { get; set; }
        public string dob { get; set; }
        public string employment_date { get; set; }
        public string dismissal_date { get; set; }
        public Bitmap photo { get; set; }
        public byte[] bytes_photo { get; set; }
        public string addr { get; set; }
        public string phone { get; set; }
        public int education { get; set; }

    }
}