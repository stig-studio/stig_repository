using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace Employees_database.modules {

    public static class sql_data {

        public static SqlConnection connection { get; set; }
        public static DataSet data_set { get; set; }
        public static DataSet data_set_time_tracking { get; set; }
        public static DataSet data_set_users { get; set; }
        public static DataSet data_set_emp { get; set; }
        public static Employee curr_employee { get; set; }
    }
}