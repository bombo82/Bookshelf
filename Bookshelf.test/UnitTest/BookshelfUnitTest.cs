using System;
using System.Collections.Generic;
using System.Text;
using Bookshelf.Controllers;
using Bookshelf.Model.Bookshelf.Models;
using Bookshelf.Services;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace Bookshelf.test.UnitTest
{
    public class BookshelfUnitTest
    {
        [Test]
        public void PostABook()
        {
            Book book = new Book();
            var test = BookshelfService.AddBook(book);

            Assert.That(test, Is.True);
        }
    }
}
