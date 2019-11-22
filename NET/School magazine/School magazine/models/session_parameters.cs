using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School_magazine.models {

    public static class session_parameters {

        public static User current_user { get; set; }
        public static int semestr { get; set; }
        public static int lesson_id { get; set; }
        public static string lesson_date { get; set; }

    }
}