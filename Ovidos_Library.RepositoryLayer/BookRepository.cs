using Ovidos_Library.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovidos_Library.RepositoryLayer
{
    public class BookRepository : IRepository<Book>
    {
        public static List<Book> GetCacheBooks()
        {
            Repository rp = new Repository();
            List<Book> books = new List<Book>();
            if (rp.GetAllObject<Book>("Book") == null)
            {
                using (LibraryContext db = new LibraryContext())
                {
                    books = db.Books.ToList();
                }
                rp.CacheAdd(books, "Book");
            }
            return rp.GetAllObject<Book>("Book");
        }

        public void AddEntity(Book entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateEntity(Book entity)
        {
            throw new NotImplementedException();
        }
    }
}
