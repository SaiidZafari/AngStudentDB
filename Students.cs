using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngStudentDB
{
    public class Students
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int TotalMarks { get; set; }
        public int SubjectID { get; set; }
    }
}