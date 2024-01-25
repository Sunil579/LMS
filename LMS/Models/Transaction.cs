
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.Models
{
        public class Transaction
    {

        public int TransactionID { get; set; }
        public String TransactionNAme { get; set; }
        public int BorrowingID { get; set; }
        public int StudentID { get; set; }
        public DateTime TransDate { get; set; }
    }
}
