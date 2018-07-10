using Ovidos_Library.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovidos_Library.RepositoryLayer
{
    public class BookTransactionRepository : IRepository<BookTransaction>
    {
        public static List<BookTransaction> GetCacheBookTransactions()
        {
            Repository rp = new Repository();
            List<BookTransaction> booktransactions = new List<BookTransaction>();
            if (rp.GetAllObject<BookTransaction>("BookTransaction") == null)
            {
                using (LibraryContext db = new LibraryContext())
                {
                    booktransactions = db.BookTransactions.ToList();
                }
                rp.CacheAdd(booktransactions, "BookTransaction");
            }
            return rp.GetAllObject<BookTransaction>("BookTransaction");
        }
        
        public void AddEntity(BookTransaction entity)
        {
            try
            {
                using (LibraryContext db = new LibraryContext())
                {
                    db.BookTransactions.Add(entity);
                    db.SaveChanges();

                    Repository rp = new Repository();
                    rp.CacheRefresh("BookTransaction");
                }
            }
            catch (Exception)
            {

            }
        }
        

        public void UpdateEntity(BookTransaction entity)
        {
            throw new NotImplementedException();
        }
    }
}
