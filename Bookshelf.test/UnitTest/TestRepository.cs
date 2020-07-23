using Bookshelf.Model.Bookshelf.Models;
using Bookshelf.Repositories;
using System.Collections.Generic;

namespace Bookshelf.test.UnitTest
{
    public class TestRepository : IBookshelfRepository
    {
        public readonly IList<string> logAddedIds;

        public TestRepository()
        {
            logAddedIds = new List<string>();
        }

        // spy
        public void AddABook(Book bookToAdd)
        {
            logAddedIds.Add(bookToAdd.Id);
        }

        public Book DeleteABook(string id)
        {
            throw new System.NotImplementedException();
        }

        // dummy
        public IList<Book> GetAllBooks()
        {
            List<Book> listOfBooks = new List<Book>();

            Book bookOne = new Book();
            listOfBooks.Add(bookOne);

            Book bookTwo = new Book();
            listOfBooks.Add(bookTwo);


            return listOfBooks;
        }

        // stub
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
