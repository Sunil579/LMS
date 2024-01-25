using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.Models
{
    public class Students
    {
        public int StudentsID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Gender { get; set; }

        public int Age { get; set; }
        public int PhoneNum { get; set; }
        public String StudentEmail { get; set; }
        public String StudentPassword { get; set; }



    }
}