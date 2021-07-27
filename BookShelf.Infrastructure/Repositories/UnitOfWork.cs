using System;
using BookShelf.Core.Repositories;
using BookShelf.Infrastructure.Database;
using Microsoft.EntityFrameworkCore.Storage;

namespace BookShelf.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IDbContextTransaction _entityTransaction;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            if (_entityTransaction == null)
            {
                _entityTransaction = _context.Database.BeginTransaction();
            }
            else
            {
                throw new InvalidOperationException("There is already a transaction.");
            }
        }

        public void Commit()
        {
            _entityTransaction.Commit();
            _entityTransaction.Dispose();
            _entityTransaction = null;
        }

        public void Rollback()
        {
            _entityTransaction.Rollback();
            _entityTransaction.Dispose();
            _entityTransaction = null;
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        #region Implementation of IDisposable

        private bool _alreadyDisposed;

        ~UnitOfWork()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool isDisposing)
        {
            if (_alreadyDisposed) return;

            try
            {
                if (isDisposing)
                {
                    // free managed resources
                    if (_entityTransaction != null)
                    {
                        _entityTransaction.Dispose();
                        _entityTransaction = null;
                    }
                    _context.Dispose();
                }
            }
            finally
            {
                _alreadyDisposed = true;
            }
        }

        #endregion
    }
}