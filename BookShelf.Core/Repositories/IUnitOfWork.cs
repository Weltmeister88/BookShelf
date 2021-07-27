using System;

namespace BookShelf.Core.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
        public int SaveChanges();
    }
}