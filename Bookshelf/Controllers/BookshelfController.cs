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
            Book book = _service.GetBook(id);

            if (book == null)
            {
                return new NotFoundResult();
            }
            return Ok(book);
        }

        [HttpPost]
        public ActionResult<Book> Create(Book book)
        {
            _service.AddBook(book);

            return new ActionResult<Book>(book);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, Book book)
        {
            _service.UpdateBook(id, book);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            Book bookToDelete = _service.DeleteBook(id);
            if (bookToDelete == null) return new NotFoundResult();
            return Ok(bookToDelete);
        }
    }
}