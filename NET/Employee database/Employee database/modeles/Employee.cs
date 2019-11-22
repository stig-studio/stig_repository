using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Employees_database {

    public class Employee {

        public int id { get; set; }
        public string last_name { get; set; }
        public string first_name { get; set; }
        public string patronymic_name { get; set; }
        public DateTime birthday { get; set; }
        public string position { get; set; }
        public DateTime employment_date { get; set; }
        public DateTime dismissal_date { get; set; }
        public string order_number { get; set; }
        public byte[] photo { get; set; }
        public string address { get; set; }
        public string phone_number { get; set; }
        public bool role_is_admin { get; set; }

    }
}