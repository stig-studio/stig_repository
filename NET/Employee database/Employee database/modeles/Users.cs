using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Employee_database.modeles {

    class Users {

        public int id { get; set; } 
        public int employee_id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public bool is_admin { get; set; }

    }
}