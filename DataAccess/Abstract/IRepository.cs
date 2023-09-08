using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IRepository<T>
    {
        List<T> GetAll();   

        T GetByFilter(Expression<Func<T, bool>> filter);

        List<T> GetListByFilter(Expression<Func<T, bool>> filter);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);


    }
}
