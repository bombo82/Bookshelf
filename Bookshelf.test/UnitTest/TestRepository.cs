using Bookshelf.Model.Bookshelf.Models;
using Bookshelf.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookshelf.test.UnitTest
{
    public class TestRepository : IBookshelfRepository
    {
        public readonly IList<Book> Books;

        public TestRepository()
        {
            Books = new List<Book>();
        }

        public void AddABook(Book bookToAdd)
        {
            Books.Add(bookToAdd);
        }
    }
}
