using Bookshelf.Model.Bookshelf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookshelf.Repositories
{
    public class BookshelfRepository : IBookshelfRepository
    {
        private List<Book> Books = new List<Book>();

        public void AddABook(Book bookToAdd)
        {
            Books.Add(bookToAdd);
        }
    }
}
