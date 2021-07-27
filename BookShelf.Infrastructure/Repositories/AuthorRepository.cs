using BookShelf.Core.Models;
using BookShelf.Core.Repositories;
using BookShelf.Infrastructure.Database;

namespace BookShelf.Infrastructure.Repositories
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
