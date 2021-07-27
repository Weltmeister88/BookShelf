using BookShelf.Core.Models;
using BookShelf.Core.Repositories;
using BookShelf.Infrastructure.Database;

namespace BookShelf.Infrastructure.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
