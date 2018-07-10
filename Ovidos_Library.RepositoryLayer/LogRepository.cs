using Ovidos_Library.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovidos_Library.RepositoryLayer
{
    public class LogRepository : IRepository<Log>
    {
        public static List<Log> GetCacheLogs()
        {
            Repository rp = new Repository();
            List<Log> logs = new List<Log>();
            if (rp.GetAllObject<Log>("Log") == null)
            {
                using (LibraryContext db = new LibraryContext())
                {
                    logs = db.Logs.ToList();
                }
                rp.CacheAdd(logs, "Log");
            }
            return rp.GetAllObject<Log>("Log");
        }

        public static void NewLog(int bookID, int userID)
        {
            try
            {
                Log log = new Log();
                log.TransactionDate = DateTime.Now;
                log.UserID = userID;
                log.TransactionDescription = "'" + BookRepository.GetCacheBooks().FirstOrDefault(x => x.ID == bookID).Name + "' is reserved by " + UserRepository.GetCacheUsers().FirstOrDefault(x => x.ID == userID).Username + ".";
                LogRepository lr = new LogRepository();
                lr.AddEntity(log);
            }
            catch (Exception)
            {
                
            }
        }

        public void AddEntity(Log entity)
        {
            try
            {
                using (LibraryContext db = new LibraryContext())
                {
                    db.Logs.Add(entity);
                    db.SaveChanges();

                    Repository rp = new Repository();
                    rp.CacheRefresh("Log");
                }
            }
            catch (Exception)
            {

            }
        }

        public void UpdateEntity(Log entity)
        {
            throw new NotImplementedException();
        }
    }
}
