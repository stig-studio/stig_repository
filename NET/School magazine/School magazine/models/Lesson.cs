using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School_magazine.models {

    public class Lesson {

        public int id { get; set; }
        public int subj_id { get; set; }
        public string subj_name { get; set; }
        public string lesson_date { get; set; }
        public string lesson_topic { get; set; }
        public string lesson_report { get; set; }

    }
}