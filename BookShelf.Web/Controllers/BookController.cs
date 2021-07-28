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
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookController(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BookDto>))]
        public ActionResult<IEnumerable<BookDto>> Get()
        {
            return Ok(_mapper.Map<IEnumerable<Book>, IEnumerable<BookDto>>(_bookRepository.GetAll()));
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BookDto))]
        public ActionResult<BookDto> Get(int id)
        {
            var book = _bookRepository.Get(id);
            if (book == null)
            {
                return NotFound(id);
            }
            return Ok(_mapper.Map<BookDto>(book));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        public ActionResult Post([FromBody] BookAddDto book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Book entity = _mapper.Map<Book>(book);
            _bookRepository.Add(entity);
            return Ok(entity.Id);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult Put([FromBody] BookDto book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existingBook = _bookRepository.Get(book.Id);
            if (existingBook == null)
            {
                return NotFound(book.Id);
            }
            _bookRepository.Update(_mapper.Map(book, existingBook));
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult Delete(int id)
        {
            var book = _bookRepository.Get(id);
            if (book == null)
            {
                return NotFound(id);
            }
            _bookRepository.Remove(book);
            return NoContent();
        }
    }
}