using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace School_magazine.models {

    public class Student {

        public int id { get; set; }
        public string last_name { get; set; }
        public string first_name { get; set; }
        public string patr_name { get; set; }
        public string dob { get; set; }
        public string mother { get; set; }
        public string mother_phone { get; set; }
        public string father { get; set; }
        public string father_phone { get; set; }
        public Bitmap photo { get; set; }
        public byte[] bytes_photo { get; set; }
        public string addr { get; set; }
        public string phone { get; set; }
        public int class_id { get; set; }

    }
}