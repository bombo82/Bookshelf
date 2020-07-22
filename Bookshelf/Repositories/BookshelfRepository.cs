using Bookshelf.Model.Bookshelf.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

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
           return Books.Where(b => b.Id == id).First();
        }
    }
}
