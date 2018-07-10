using Ovidos_Library.EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ovidos_Library.RepositoryLayer
{
    public class Repository
    {
        LibraryContext db = new LibraryContext();

        private static List<EntityCache> _entityCache;
        public static List<EntityCache> entityCache
        {
            get
            {
                if (_entityCache == null)
                {
                    _entityCache = new List<EntityCache>();
                }
                return _entityCache;
            }
        }

        public void CacheAdd(object ObjectData,string ObjectName)
        {
            EntityCache ec = new EntityCache();
            ec.ObjectData = ObjectData;
            ec.ObjectName = ObjectName;
            _entityCache.Add(ec);
        }

        public void CacheRefresh(string ObjectName)
        {
            _entityCache.RemoveAll(x=>x.ObjectName==ObjectName);
        }

        public List<T> GetAllObject<T>(string ObjectName) where T:class
        {
            EntityCache ec = entityCache.FirstOrDefault(x=>x.ObjectName==ObjectName);
            if (ec==null)
            {
                return null;
            }
            return (List<T>)ec.ObjectData;
        }
    }
}
