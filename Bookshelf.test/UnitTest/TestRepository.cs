using Bookshelf.Model.Bookshelf.Models;
using Bookshelf.Repositories;
using System.Collections.Generic;

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

        public IList<Book> GetAllBooks()
        {
            List<Book> listOfBooks = new List<Book>();

            Book bookOne = new Book();
            listOfBooks.Add(bookOne);

            Book bookTwo = new Book();
            listOfBooks.Add(bookTwo);


            return listOfBooks;
        }

        public Book GetBookById(string id)
        {
            if (id == "5")
            {
                return null;
            }
            Book bookOne = new Book();
            bookOne.Id = id;
            return bookOne;
        }
    }
}
