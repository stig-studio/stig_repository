using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School_magazine.models {

    public class MarkAndVisit {

        public int id { get; set; }
        public int lesson_id { get; set; }
        public int students_id { get; set; }
        public int visit {get; set; }
        public int mark_homework { get; set; }
        public int mark_classwork { get; set; }
        public int mark_independent_work { get; set; }
        public int mark_test_work { get; set; }
        public int mark_exam { get; set; }

    }
}