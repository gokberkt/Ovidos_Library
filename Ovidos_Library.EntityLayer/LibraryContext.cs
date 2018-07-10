using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovidos_Library.EntityLayer
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<BookStock> BookStocks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BookTransaction> BookTransactions { get; set; }
        public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().ToTable("Book");
            modelBuilder.Entity<BookStock>().ToTable("BookStock");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<BookTransaction>().ToTable("BookTransaction");
            modelBuilder.Entity<Log>().ToTable("Log");
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
