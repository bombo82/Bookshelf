using Bookshelf.Model.Bookshelf.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Bookshelf.Repositories
{
    public class BookshelfRepository : IBookshelfRepository
    {
        private List<Book> Books = new List<Book>();

        public void AddABook(Book bookToAdd)
        {
            Books.Add(bookToAdd);
        }

        public IList<Book> GetAllBooks()
        {
            return Books.ToImmutableList();
        }

        public Book GetBookById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
