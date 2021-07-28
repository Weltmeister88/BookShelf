using System.Linq;
using BookShelf.Core.Models;
using BookShelf.Core.Repositories;
using BookShelf.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace BookShelf.Infrastructure.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override IQueryable<Book> GetAll()
        {
            return base.GetAll().Include(book => book.Author);
        }
    }
}
