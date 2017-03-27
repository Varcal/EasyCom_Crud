using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Easy.Domain.Contracts.Repositories.Base;
using Easy.Domain.Entities.Base;
using Easy.Infra.Data.Contexts;

namespace Easy.Infra.Data.Repositories.Base
{
    public abstract class RepositoryBase<T>: IRepositoryBase<T> where T: EntityBase
    {
        protected EfContext Db;

        protected RepositoryBase(EfContext db)
        {
            Db = db;
        }

        public virtual void Add(T entity)
        {
            Db.Set<T>().Add(entity);
        }

        public virtual void Update(T entity)
        {
            Db.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Remove(T entity)
        {
            Db.Set<T>().Remove(entity);
        }

        public virtual T GetById(int id)
        {
            return Db.Set<T>().Find(id);
        }

        public virtual IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includes)
        {
            var query = Db.Set<T>().AsQueryable();

            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            return query.ToList();
        }

    }
}
