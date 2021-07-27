using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BookShelf.Core.Models;
using BookShelf.Core.Repositories;
using BookShelf.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace BookShelf.Infrastructure.Repositories
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Entity
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<TEntity> _entities;

        protected GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            _entities.Add(entity);
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            _entities.AddRange(entities);
        }

        public virtual void Update(TEntity entity)
        {
            _entities.Update(entity);
        }

        public virtual void UpdateRange(IEnumerable<TEntity> entities)
        {
            _entities.UpdateRange(entities);
        }

        public virtual void Remove(TEntity entity)
        {
            _entities.Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            _entities.RemoveRange(entities);
        }

        public virtual int Count()
        {
            return _entities.Count();
        }

        public virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.Where(predicate);
        }

        public virtual TEntity GetSingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.SingleOrDefault(predicate);
        }

        public virtual TEntity Get(int id)
        {
            return _entities.Find(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _entities.AsQueryable();
        }
    }
}
