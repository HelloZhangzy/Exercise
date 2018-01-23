using City_Repository.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace City_Repository.DAL
{
    public abstract class BaseDAL<T> : IBaseDAL<T> where T : class
    {
        protected m baseContext;
        protected IDbSet<T> objectSet;

        public BaseDAL(DbContext context)
        {
            this.baseContext = context;
            this.objectSet = this.baseContext.Set<T>();
        }

        public T Get(object id)
        {
            return objectSet.Find(id);
        }

        public IList<T> GetAll()
        {
            return objectSet.ToList<T>(); ;
        }

        public IList<T> GetAll(Expression<Func<T, bool>> whereCondition)
        {
            return objectSet.Where(whereCondition).ToList<T>();
        }
    }
}
