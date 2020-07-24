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
        private int lastId = 0;

        public BookshelfService(IBookshelfRepository repository)
        {
            _repository = repository;
        }

        public Book AddBook(Book book) 
        {
            book.Id = lastId++.ToString();
            _repository.AddABook(book);
            
            return book;
        }

        public IList<Book> GetBooks()
        {
            return _repository.GetAllBooks();
        }

        public Book GetBook(string id)
        {
            try
            {
                return _repository.GetBookById(id);
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        public Book UpdateBook(string id, Book book)
        {
            if(GetBook(id) != null)
            {
                book.Id = id;
                _repository.UpdateBook(id, book);
                return book;
            }
            else
            {
                return null;
            }
           
        }

        public Book DeleteBook(string id)
        {

            try
            {
                var book =_repository.GetBookById(id);
                          _repository.DeleteABook(id);

                return book;
                
            }
            catch(InvalidOperationException)
            {
                return null;
            }
            
        }
    }
}
