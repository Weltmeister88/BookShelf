using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BookShelf.Core.Database;
using BookShelf.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShelf.Infrastructure.Database
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // FIXME: load connection string from configuration
            optionsBuilder.UseInMemoryDatabase("BookShelfDb");
            base.OnConfiguring(optionsBuilder);
        }

        public override int SaveChanges()
        {
            SetAuditingInfo();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken)
        {
            SetAuditingInfo();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            SetAuditingInfo();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void SetAuditingInfo()
        {
            var entities = ChangeTracker.Entries()
                .Where(x => x.Entity is AuditedEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                var now = DateTime.UtcNow; // current datetime

                var auditedEntity = (AuditedEntity)entity.Entity;
                if (entity.State == EntityState.Added)
                {
                    auditedEntity.CreatedUtc = now;
                }
                auditedEntity.ModifiedUtc = now;
            }
        }
    }
}
