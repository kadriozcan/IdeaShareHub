using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Repositories
{
    public class EfRepositoryBase<T> : IRepository<T> where T : class
    {
        private readonly Context context = new Context();
        private readonly DbSet<T> _dbSet;

        public EfRepositoryBase()
        {
            _dbSet = context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetByFilter(Expression<Func<T, bool>> filter)
        {
            return _dbSet.SingleOrDefault(filter);
        }

        public List<T> GetListByFilter(Expression<Func<T, bool>> filter)
        {
            return _dbSet.Where(filter).ToList();
        }

        public void Update(T entity)
        {
            context.SaveChanges();
        }
    }
}
