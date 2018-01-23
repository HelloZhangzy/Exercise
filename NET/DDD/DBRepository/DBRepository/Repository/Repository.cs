using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBRepository.DAL;
using System.Data.Entity;
using System.Linq.Expressions;

namespace DBRepository.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal XEContext context;
        internal DbSet<TEntity> dbSet;

        public Repository(XEContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(object ID)
        {
            TEntity t = dbSet.Find(ID);
            dbSet.Remove(t);
        }

        public void Dispose()
        {
            this.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<TEntity> Get()
        {
            return dbSet.ToList();
        }

        public TEntity GetByID(object ID)
        {
            return dbSet.Find(ID);
        }

        public IEnumerable<TEntity> Query(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = dbSet;
            if (filter!=null)
            {
                query = query.Where(filter);
            }

            //foreach (var item in includePoroperties.Split(new char[] { ','},StringSplitOptions.RemoveEmptyEntries))
            //{
            //    query = query.Include(item);
            //}
            //if (orderBy !=null)
            //{
            //    return orderBy(query);
            //}
            //else
            //{
                return query;
            //}

        }

        public void Save()
        {
            this.context.SaveChanges(); 
        }

        public void Update(TEntity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        
    }
}
