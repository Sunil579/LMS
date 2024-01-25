using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public String BookTitle { get; set; }
        public String Type { get; set; }
        public String Genre { get; set; }
        public String Publisher { get; set; }
        public String Auther { get; set; }
        public int BookNumber { get; set; }
        public DateTime PublishedxDatte { get; set; }

        public int CopiesAvailable { get; set; }
        public int CopiesTotal { get; set; }

    }
}
