using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.Models
{
    public class Report
    {

        public int ReportID { get; set; }
        public int TransactionID { get; set; }
        public int BorrowingID { get; set; }
        public DateTime ReportDate { get; set; }

        public int CopiesAvailabe { get; set; }
        public int CopiesTotal { get; set; }
    }
}