using System;
using System.Linq;
using System.Linq.Expressions;
using WebApp.Core.Entities;

namespace WebApp.Core
{
    public interface IRepository<T> where T : Entity
    {
        T GetById(int id);

        T FirstOrDefault(Expression<Func<T, bool>> predicate);

        IQueryable<T> GetAllAsQueryable();

        T Add(T entity);

        T Update(T entity);

        void Delete(int id, bool isHard = false);

        void Save();
    }
}