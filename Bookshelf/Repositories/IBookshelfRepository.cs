using Bookshelf.Model.Bookshelf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookshelf.Repositories
{
    public interface IBookshelfRepository
    {
        void AddABook(Book bookToAdd);

        IList<Book> GetAllBooks();

        Book GetBookById(string id);

        void UpdateBook(string id, Book newBook);

        void DeleteABook(string id);
    }
}
