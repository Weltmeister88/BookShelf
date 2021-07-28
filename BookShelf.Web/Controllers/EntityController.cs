using BookShelf.Core.Models;
using BookShelf.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookShelf.Web.Controllers
{
    public abstract class EntityController<TEntityRepository, TEntity> : ControllerBase, IEntityController
        where TEntityRepository : IGenericRepository<TEntity>
        where TEntity : Entity
    {
        protected readonly TEntityRepository Repository;

        protected EntityController(TEntityRepository repository)
        {
            Repository = repository;
        }
    }
}