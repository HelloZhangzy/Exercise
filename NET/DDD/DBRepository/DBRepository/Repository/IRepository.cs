using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DBRepository.Repository
{
    public interface IRepository<TEntity>:IDisposable where TEntity:class
    {
        IEnumerable<TEntity> Get();
        TEntity GetByID(object ID);
        void Add(TEntity entity);
        void Delete(object ID);
        void Update(TEntity entity);
        IEnumerable<TEntity> Query(Expression<Func<TEntity, bool>> filter=null);
        void Save();
    }
}
