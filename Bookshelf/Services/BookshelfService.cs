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

        public bool AddBook(Book book) 
        {
            _repository.AddABook(book);
            return true;
        }
    }
}
