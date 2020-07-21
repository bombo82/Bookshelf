using Bookshelf.Controllers;
using Bookshelf.Model.Bookshelf.Models;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;

namespace Bookshelf.AcceptanceTest
{
    public class Bookshelf_Should
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreateABook()
        {
            BookshelfController controller = new BookshelfController();
            Book book = new Book();
            ActionResult<Book> actionResult = controller.Create(book);

            Assert.That(actionResult, Is.InstanceOf<IActionResult>());
        }
    }
}