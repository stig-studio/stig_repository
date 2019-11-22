using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School_magazine.models {

    public class User {

        public int Id { get; set; }
        public int employee_id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

    }
}