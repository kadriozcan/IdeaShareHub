using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IRepository<T>
    {
        List<T> GetAll();   

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        List<T> GetByFilter(Expression<Func<T, bool>> filter);

    }
}
