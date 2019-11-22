using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Employee_database {

    class TimeTracking {

        public int code { get; set; }
        public int employee_id { get; set; }
        public string employee_full_name { get; set; }
        public string arrival { get; set; }
        public string leaving { get; set; }
    }
}