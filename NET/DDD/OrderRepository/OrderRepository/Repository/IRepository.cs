using OrderRepository.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderRepository.Repository
{    
    public interface IRepository<TEntity> where TEntity : EntityObject
    {
        void Add(TEntity entity);
        TEntity GetByKey(int id);
        IEnumerable<TEntity> FindBySpecification(Func<TEntity, bool> spec);
        void Remove(TEntity entity);
        void Update(TEntity entity);
    }    
}
