using Bookshelf.Controllers;
using Bookshelf.Model.Bookshelf.Models;
using Bookshelf.Repositories;
using Bookshelf.Services;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System.Collections.Generic;

namespace Bookshelf.AcceptanceTest
{
    public class Bookshelf_Should
    {
        private IBookshelfRepository repository;
        private BookshelfService service;
        private BookshelfController controller;

        [SetUp]
        public void Setup()
        {
            repository = new BookshelfRepository();
            service = new BookshelfService(repository);
            controller = new BookshelfController(service);
        }

        [Test]
        public void CreateABook()
        {
            Book book = new Book("Il signore degli anelli", "Tolkien");
            ActionResult<Book> actionResult = controller.Create(book);

            Assert.That(actionResult, Is.InstanceOf<ActionResult<Book>>());
            Assert.That(actionResult.Value, Is.Not.Null);
            Assert.That(actionResult.Value.Title, Is.EqualTo("Il signore degli anelli"));
            Assert.That(actionResult.Value.Author, Is.EqualTo("Tolkien"));
            Assert.That(actionResult.Value.Id, Is.Not.Null);
        }

        [Test]
        public void GetListOfBooks()
        {
            controller.Create(new Book("Extreme Programming Explained", "Beck"));
            controller.Create(new Book("Clean Code", "Uncle Bob"));

            OkObjectResult result = controller.Get() as OkObjectResult;

            var books = result.Value;
            Assert.That(books, Is.Not.Null);
        }

        [Test]
        public void GetBookById()
        {
            controller.Create(new Book("Extreme Programming Explained", "Beck"));
            controller.Create(new Book("Clean Code", "Uncle Bob"));

            OkObjectResult result = controller.Get("1") as OkObjectResult;
            var book = result.Value;
            Assert.That(book, Is.Not.Null);
        }

        [Test]
        public void GetBookByIdWithNotFound()
        {
            controller.Create(new Book("Extreme Programming Explained", "Beck"));
            controller.Create(new Book("Clean Code", "Uncle Bob"));

            NotFoundResult result = controller.Get("5") as NotFoundResult;
            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }

        [Test]
        public void ShouldDelete_ABook()
        {
            controller.Create(new Book("Extreme Programming Explained", "Beck"));
            controller.Create(new Book("Clean Code", "Uncle Bob"));

            var result = controller.Delete("1");

            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public void UpdateTest()
        {
            controller.Create(new Book("Extreme Programming Explained", "Beck"));
            controller.Create(new Book("Clean Code", "Uncle Bob"));

            Book newBook = new Book("Not Clean Code", "Robert C. Martin");

            var result = controller.Update("1", newBook);

            Assert.That(result, Is.InstanceOf<OkResult>());
        }

        [Test]
        public void DeleteShouldReturnNotFound()
        {
            controller.Create(new Book("Extreme Programming Explained", "Beck"));
            controller.Create(new Book("Clean Code", "Uncle Bob"));
            NotFoundResult result = controller.Delete("3") as NotFoundResult;
            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }
    }
}