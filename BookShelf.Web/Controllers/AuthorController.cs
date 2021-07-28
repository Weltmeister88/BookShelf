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
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AuthorController(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<AuthorDto>))]
        public ActionResult<IEnumerable<AuthorDto>> Get()
        {
            return Ok(_mapper.Map<IEnumerable<Author>, IEnumerable<AuthorDto>>(_authorRepository.GetAll()));
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AuthorDto))]
        public ActionResult<AuthorDto> Get(int id)
        {
            var author = _authorRepository.Get(id);
            if (author == null)
            {
                return NotFound(id);
            }
            return Ok(_mapper.Map<AuthorDto>(author));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        public ActionResult Post([FromBody] AuthorAddDto author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Author entity = _mapper.Map<Author>(author);
            _authorRepository.Add(entity);
            return Ok(entity.Id);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult Put([FromBody] AuthorDto author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existingAuthor = _authorRepository.Get(author.Id);
            if (existingAuthor == null)
            {
                return NotFound(author.Id);
            }
            _authorRepository.Update(_mapper.Map(author, existingAuthor));
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult Delete(int id)
        {
            var author = _authorRepository.Get(id);
            if (author == null)
            {
                return NotFound(id);
            }
            _authorRepository.Remove(author);
            return NoContent();
        }
    }
}