using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.Models
{
    public class Borrowing
    {
        public int BorrowingID { get; set; }
        public int MyProperty { get; set; }
        public int BookID { get; set; }
        public int StudentID { get; set; }
        public DateTime DateBorrowed { get; set; }
        public DateTime DateRetuened { get; set; }


    }
}
