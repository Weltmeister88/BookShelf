using System.Collections.Generic;
using AutoMapper;
using BookShelf.Core.Models;
using BookShelf.Core.Repositories;
using BookShelf.Web.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookShelf.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : EntityController<IAuthorRepository, Author>
    {
        private readonly IMapper _mapper;

        public AuthorController(IAuthorRepository authorRepository, IMapper mapper)
            : base(authorRepository)
        {
            _mapper = mapper;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<AuthorDto>))]
        public ActionResult<IEnumerable<AuthorDto>> Get()
        {
            return Ok(_mapper.Map<IEnumerable<Author>, IEnumerable<AuthorDto>>(Repository.GetAll()));
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AuthorDto))]
        public ActionResult<AuthorDto> Get(int id)
        {
            var author = Repository.Get(id);
            if (author == null) return NotFound(id);
            return Ok(_mapper.Map<AuthorDto>(author));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        public ActionResult Post([FromBody] AuthorAddDto author)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var entity = _mapper.Map<Author>(author);
            Repository.Add(entity);
            return Ok(entity.Id);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult Put([FromBody] AuthorDto author)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var existingAuthor = Repository.Get(author.Id);
            if (existingAuthor == null) return NotFound(author.Id);
            Repository.Update(_mapper.Map(author, existingAuthor));
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult Delete(int id)
        {
            var author = Repository.Get(id);
            if (author == null) return NotFound(id);
            Repository.Remove(author);
            return NoContent();
        }
    }
}