using System.Collections.Generic;
using BookShelf.Core.Models;
using BookShelf.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        // GET: api/<AuthorController>
        [HttpGet]
        public IEnumerable<Author> Get()
        {
            return _authorRepository.GetAll();
        }

        // GET api/<AuthorController>/5
        [HttpGet("{id}")]
        public Author Get(int id)
        {
            return _authorRepository.Get(id);
        }

        // POST api/<AuthorController>
        [HttpPost]
        public void Post([FromBody] Author author)
        {
            _authorRepository.Add(author);
        }

        // PUT api/<AuthorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Author author)
        {
            _authorRepository.Update(author);
        }

        // DELETE api/<AuthorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var author = _authorRepository.Get(id);
            _authorRepository.Remove(author);
        }
    }
}