using System.Collections.Generic;
using System.Linq;
using BookShelf.Core.Repositories;
using BookShelf.Web.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookShelf.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<SelectItemDto<int, string>>))]
        public ActionResult<IEnumerable<SelectItemDto<int, string>>> Get()
        {
            return Ok(_authorRepository.GetAll()
                .Select(author => new SelectItemDto<int, string>(author.Id, author.ToString())));
        }
    }
}