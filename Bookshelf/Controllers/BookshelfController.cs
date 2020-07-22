using Bookshelf.Model.Bookshelf.Models;
using Bookshelf.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Bookshelf.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookshelfController : ControllerBase
    {
        BookshelfService _service;

        public BookshelfController(BookshelfService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult Get()
        {
            IList<Book> books = _service.GetBooks();
            return Ok(new { Values = books });
        }

        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult<Book> Create(Book book)
        {
            _service.AddBook(book);

            return new ActionResult<Book>(book);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, Book bookIn)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}