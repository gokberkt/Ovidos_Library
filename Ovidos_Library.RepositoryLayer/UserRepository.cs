using Ovidos_Library.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovidos_Library.RepositoryLayer
{
    
    public class UserRepository : IRepository<User>
    {
        public static List<User> GetCacheUsers()
        {
            Repository rp = new Repository();
            List<User> users = new List<User>();
            if (rp.GetAllObject<User>("User") == null)
            {
                using (LibraryContext db = new LibraryContext())
                {
                    users = db.Users.ToList();
                }
                rp.CacheAdd(users, "User");
            }
            return rp.GetAllObject<User>("User");
        }

        public void AddEntity(User entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateEntity(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
