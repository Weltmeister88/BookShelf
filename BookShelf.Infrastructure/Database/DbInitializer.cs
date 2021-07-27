using BookShelf.Core.Database;
using System.Linq;
using BookShelf.Core.Models;

namespace BookShelf.Infrastructure.Database
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _dbContext;

        public DbInitializer(ApplicationDbContext dbContext)
        {
            // NOTE: Database property can also be defined on the interface
            _dbContext = dbContext;
        }

        public void Initialize()
        {
            _dbContext.Database.EnsureCreated();

            if (_dbContext.Books.Any())
            {
                return;
            }

            var authors = new []
            {
                new Author
                {
                    FirstName = "Steven",
                    LastName = "King",
                    Books = new []
                    {
                        new Book
                        {
                            Title = "Dreamcatcher",
                            Description = "Dreamcatcher is a 2001 science fiction horror novel by American writer Stephen King, featuring elements of body horror, suspense and alien invasion.",
                            Genre = Genre.ScienceFiction
                        },
                        new Book
                        {
                            Title = "Pet Sematary",
                            Description = "Pet Sematary is a 1983 horror novel by American writer Stephen King. The novel was nominated for a World Fantasy Award for Best Novel in 1986, and adapted into two films.",
                            Genre = Genre.Horror
                        }
                    }
                },
                new Author
                {
                    FirstName = "Jules",
                    LastName = "Verne",
                    Books = new []
                    {
                        new Book
                        {
                            Title = "From the Earth to the Moon‎",
                            Description = "From the Earth to the Moon: A Direct Route in 97 Hours, 20 Minutes is an 1865 novel by Jules Verne.",
                            Genre = Genre.ScienceFiction
                        }
                    }
                },
                new Author
                {
                    FirstName = "Fyodor",
                    LastName = "Dostoevsky",
                    Books = new []
                    {
                        new Book
                        {
                            Title = "Crime and Punishment",
                            Description = "Crime and Punishment is a novel by the Russian author Fyodor Dostoevsky. It was first published in the literary journal The Russian Messenger in twelve monthly installments during 1866. It was later published in a single volume.",
                            Genre = Genre.Crime
                        },
                        new Book
                        {
                            Title = "The Brothers Karamazov",
                            Description = "The Brothers Karamazov, also translated as The Karamazov Brothers, is the last novel by Russian author Fyodor Dostoevsky.",
                            Genre = Genre.Philosophical
                        }
                    }
                }
            };

            _dbContext.Authors.AddRange(authors);
            _dbContext.SaveChanges();
        }
    }
}