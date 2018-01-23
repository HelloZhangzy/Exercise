using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderRepository.Repository
{
    internal class EdmRepository<TEntity> : IRepository<TEntity>
    where TEntity : EntityObject
    {
        #region Private Fields
        private readonly ObjectContext objContext;
        private readonly string entitySetName;
        #endregion

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objContext"></param>
        public EdmRepository(ObjectContext objContext)
        {
            this.objContext = objContext;           
        }
        #endregion

        #region IRepository<TEntity> Members
        public void Add(TEntity entity)
        {
            this.objContext.AddObject(EntitySetName, entity);
        }

        public TEntity GetByKey(int id)
        {
            string eSql = string.Format("SELECT VALUE ent FROM {0} AS ent WHERE ent.Id=@id", EntitySetName);
            var objectQuery = objContext.CreateQuery<TEntity>(eSql,new ObjectParameter("id", id));
            if (objectQuery.Count() > 0) return objectQuery.First();
            throw new Exception("Not found");
        }

        public void Remove(TEntity entity)
        {
            this.objContext.DeleteObject(entity);
        }

        public void Update(TEntity entity)
        {
            // TODO
        }
        public IEnumerable<TEntity> FindBySpecification(Func<TEntity, bool> spec)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Protected Properties
        protected string EntitySetName
        {
            get { return this.entitySetName; }
        }
        protected ObjectContext ObjContext
        {
            get { return this.objContext; }
        }
        #endregion
    }
}
