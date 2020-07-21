using System;
using System.Collections.Generic;
using System.Text;
using Bookshelf.Controllers;
using Bookshelf.Model.Bookshelf.Models;
using Bookshelf.Repositories;
using Bookshelf.Services;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace Bookshelf.test.UnitTest
{
    public class BookshelfUnitTest
    {
        BookshelfService service;
        TestRepository repository;

        [SetUp]
        public void Setup()
        {
            repository = new TestRepository();
            service = new BookshelfService(repository);
        }

        [Test]
        public void PostABook()
        {
            Book book = new Book();
            var test = service.AddBook(book);

            Assert.That(test, Is.True);
        }

        [Test]
        public void Service_ShouldAddANewBook()
        {
            Book book = new Book();
            service.AddBook(book);
            
            Assert.That(repository.Books, Is.Not.Empty);
    
        }
    }
}
