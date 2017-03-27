using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Easy.Domain.Entities.Base;

namespace Easy.Domain.Contracts.Repositories.Base
{
    public interface IRepositoryBase<T> where T: EntityBase
    {
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        T GetById(int id);
        IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includes);
    }
}
