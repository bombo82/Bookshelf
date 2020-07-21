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
            IBookshelfRepository repository = new BookshelfRepository();
            BookshelfService service = new BookshelfService(repository);
        }

        [Test]
        public void CreateABook()
        {
            BookshelfController controller = new BookshelfController(service);
            Book book = new Book();
            ActionResult<Book> actionResult = controller.Create(book);

            Assert.That(actionResult, Is.InstanceOf<ActionResult<Book>>());
        }
    }
}