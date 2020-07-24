using Bookshelf.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Bookshelf.Repositories;
using Bookshelf.Model.Bookshelf.Models;

namespace Bookshelf.test.UnitTest
{
    public class BookshelfUnitTest_WithMocks
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Service_ShouldDelete_AnExistingBook()
        {
            Mock<IBookshelfRepository> repository = new Mock<IBookshelfRepository>();
            BookshelfService service = new BookshelfService(repository.Object);

            repository.Setup(repo => repo.GetBookById("1"))
                .Returns(new Book());
            
            service.DeleteBook("1");

            repository.Verify(repo => repo.DeleteABook(It.Is<string>(id => id.Equals("1"))));
        }

        [Test]
        public void Service_ShouldDelete_NotCalledWhenTHeBookDoesNotExist()
        {
            Mock<IBookshelfRepository> repository = new Mock<IBookshelfRepository>();
            BookshelfService service = new BookshelfService(repository.Object);

           
            repository.Setup(repo => repo.GetBookById("3"))
                .Throws(new InvalidOperationException());
                

            service.DeleteBook("3");
            repository.Verify(repo => repo.GetBookById(It.Is<string>(id => id.Equals("3"))));
            repository.VerifyNoOtherCalls();
        }

        [Test]
        public void UpdateTest()
        {
            Mock<IBookshelfRepository> repository = new Mock<IBookshelfRepository>();
            BookshelfService service = new BookshelfService(repository.Object);

            Book book = new Book("Titolo", "Autore");

            repository.Setup(repo => repo.GetBookById("1"))
                .Returns(new Book());

            service.UpdateBook("1", book);

            repository.Verify(repo => repo.UpdateBook(It.Is<string>(id => id.Equals("1")), It.Is<Book>(book => book.Title.Equals("Titolo") && book.Author.Equals("Autore") && book.Id.Equals("1"))));
        }

        [Test]
        public void UpdateBook_ShouldReturnUpdatedBook()
        {
            Mock<IBookshelfRepository> repository = new Mock<IBookshelfRepository>();
            BookshelfService service = new BookshelfService(repository.Object);

            Book book = new Book("Titolo", "Autore");

            repository.Setup(repo => repo.GetBookById("1"))
                .Returns(new Book());

            var result = service.UpdateBook("1", book);

            Assert.That(result, Is.EqualTo(book));
        }

        [Test]
        public void UpdateBook_ShouldReturnNull_IfBookIsNotFound()
        {
            Mock<IBookshelfRepository> repository = new Mock<IBookshelfRepository>();
            BookshelfService service = new BookshelfService(repository.Object);

            Book book = new Book("Titolo", "Autore");

            repository.Setup(repo => repo.GetBookById("2"))
               .Throws(new InvalidOperationException());

            var result = service.UpdateBook("2", book);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void UpdateBook_ShouldNotCallRepository_IfBookIsNotFound()
        {
            Mock<IBookshelfRepository> repository = new Mock<IBookshelfRepository>();
            BookshelfService service = new BookshelfService(repository.Object);

            Book book = new Book("Titolo", "Autore");

            repository.Setup(repo => repo.GetBookById("2"))
               .Throws(new InvalidOperationException());

            service.UpdateBook("2", book);

            repository.Verify(repo => repo.GetBookById(It.IsAny<string>()));
            repository.VerifyNoOtherCalls();

        }



        [Test]
        public void DeletedBook_ShouldReturnTheBook()
        {
            Mock<IBookshelfRepository> repository = new Mock<IBookshelfRepository>();
            BookshelfService service = new BookshelfService(repository.Object);
            Book expectedBook = new Book() { Id = "1" };

            repository.Setup(repo =>
            repo.GetBookById("1"))
                .Returns(expectedBook);


            Book deletedBook = service.DeleteBook("1");

            Assert.That(deletedBook, Is.EqualTo(expectedBook));
        }
    }
}
