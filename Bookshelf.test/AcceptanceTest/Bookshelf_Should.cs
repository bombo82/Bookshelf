using Bookshelf.Controllers;
using Bookshelf.Model.Bookshelf.Models;
using Bookshelf.Repositories;
using Bookshelf.Services;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;

namespace Bookshelf.AcceptanceTest
{
    public class Bookshelf_Should
    {
        private IBookshelfRepository repository;
        private BookshelfService service;

        [SetUp]
        public void Setup()
        {
            repository = new BookshelfRepository();
            service = new BookshelfService(repository);
        }

        [Test]
        public void CreateABook()
        {
            BookshelfController controller = new BookshelfController(service);
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
            BookshelfController controller = new BookshelfController(service);
            controller.Create(new Book("Extreme Programming Explained", "Beck"));
            controller.Create(new Book("Clean Code", "Uncle Bob"));

            var result = controller.Get();

            Assert.That(result, Has.Count.EqualTo(2));

        }
    }
}