using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BookShelf.Core.Models;

namespace BookShelf.Core.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : Entity
    {
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

        int Count();

        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity GetSingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        TEntity Get(int id);
        IQueryable<TEntity> GetAll();
    }
}