using LMS.Models;
using Microsoft.EntityFrameworkCore;


namespace LMS.Data
{
        public class LibraryManagementSystemContext : DbContext
        {
            public LibraryManagementSystemContext(DbContextOptions<LibraryManagementSystemContext> options) : base(options)
            { }

            public DbSet<LMS.Models.Book> Books { get; set; }

            public DbSet<LMS.Models.Librarian> Librarians { get; set; }

            public DbSet<LMS.Models.Report> Reports { get; set; }

            public DbSet<LMS.Models.Transaction> Transactions { get; set; }

            public DbSet<LMS.Models.Students> Students { get; set; }

            public DbSet<LMS.Models.Borrowing> Borrowings { get; set; }
        }
}