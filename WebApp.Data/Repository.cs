using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using WebApp.Core;
using WebApp.Core.Entities;

namespace WebApp.Data
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly ApplicationDbContext context;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public T Add(T entity)
        {
            context.Set<T>().Add(entity);

            return entity;
        }

        public void Delete(int id, bool isHard = false)
        {
            var entity = context.Set<T>().Find(id);
            if (entity != null)
            {
                if (isHard)
                {
                    context.Set<T>().Remove(entity);
                }
                else
                {
                    entity.IsDeleted = true;
                    context.Entry((T)entity).State = EntityState.Modified;
                }
            }
        }

        public T FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().FirstOrDefault(predicate);
        }

        public IQueryable<T> GetAllAsQueryable()
        {
            return context.Set<T>().AsQueryable();
        }

        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }

        public T Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}