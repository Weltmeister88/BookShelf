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
    public class BookController : EntityController<IBookRepository, Book>
    {
        private readonly IMapper _mapper;

        public BookController(IBookRepository bookRepository, IMapper mapper)
            : base(bookRepository)
        {
            _mapper = mapper;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BookListingDto>))]
        public ActionResult<IEnumerable<BookListingDto>> Get()
        {
            return Ok(_mapper.Map<IEnumerable<Book>, IEnumerable<BookListingDto>>(Repository.GetAll()));
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BookListingDto))]
        public ActionResult<BookListingDto> Get(int id)
        {
            var book = Repository.Get(id);
            if (book == null) return NotFound(id);
            return Ok(_mapper.Map<BookListingDto>(book));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        public ActionResult Post([FromBody] BookEditDto book)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var entity = _mapper.Map<Book>(book);
            Repository.Add(entity);
            return Ok(entity.Id);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult Put(int id, [FromBody] BookEditDto bookListing)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bookListing.Id)
            {
                ModelState.TryAddModelError(nameof(BookEditDto.Id), "Ids must match.");
                return BadRequest(ModelState);
            }

            var existingBook = Repository.Get(id);
            if (existingBook == null) return NotFound(bookListing.Id);
            Repository.Update(_mapper.Map(bookListing, existingBook));
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult Delete(int id)
        {
            var book = Repository.Get(id);
            if (book == null) return NotFound(id);
            Repository.Remove(book);
            return NoContent();
        }
    }
}