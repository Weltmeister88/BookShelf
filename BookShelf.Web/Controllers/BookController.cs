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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BookDto>))]
        public ActionResult<IEnumerable<BookDto>> Get()
        {
            return Ok(_mapper.Map<IEnumerable<Book>, IEnumerable<BookDto>>(Repository.GetAll()));
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BookDto))]
        public ActionResult<BookDto> Get(int id)
        {
            var book = Repository.Get(id);
            if (book == null) return NotFound(id);
            return Ok(_mapper.Map<BookDto>(book));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        public ActionResult Post([FromBody] BookAddDto book)
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
        public ActionResult Put([FromBody] BookDto book)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var existingBook = Repository.Get(book.Id);
            if (existingBook == null) return NotFound(book.Id);
            Repository.Update(_mapper.Map(book, existingBook));
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