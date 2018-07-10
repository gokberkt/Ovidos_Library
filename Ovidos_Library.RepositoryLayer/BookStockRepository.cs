using Ovidos_Library.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovidos_Library.RepositoryLayer
{
    public class BookStockRepository : IRepository<BookStock>
    {
        public static List<BookStock> GetCacheBookStocks()
        {
            Repository rp = new Repository();
            List<BookStock> bookstocks = new List<BookStock>();
            if (rp.GetAllObject<BookStock>("BookStock") == null)
            {
                using (LibraryContext db = new LibraryContext())
                {
                    bookstocks = db.BookStocks.ToList();
                }
                rp.CacheAdd(bookstocks, "BookStock");
            }
            return rp.GetAllObject<BookStock>("BookStock");
        }

        public void AddEntity(BookStock entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateEntity(BookStock entity)
        {
            try
            {
                using (LibraryContext db = new LibraryContext())
                {
                    db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    Repository rp = new Repository();
                    rp.CacheRefresh("BookStock");
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
