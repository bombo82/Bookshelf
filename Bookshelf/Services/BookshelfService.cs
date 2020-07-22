using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookshelf.Model.Bookshelf.Models;
using Bookshelf.Repositories;

namespace Bookshelf.Services
{
    public class BookshelfService
    {
        private IBookshelfRepository _repository;

        public BookshelfService(IBookshelfRepository repository)
        {
            _repository = repository;
        }

        public Book AddBook(Book book) 
        {
            book.Id = "1";
            _repository.AddABook(book);
            return book;
        }

        public IList<Book> GetBooks()
        {
            return _repository.GetAllBooks();
        }
    }
}
