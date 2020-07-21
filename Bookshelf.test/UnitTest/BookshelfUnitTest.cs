using System;
using System.Collections.Generic;
using System.Linq;
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
        public void Service_ShouldAddANewBook()
        {
            Book book = new Book();
            service.AddBook(book);
            
            Assert.That(repository.Books, Is.Not.Empty);
    
        }

        [Test]
        public void TestIdBook()
        {
            Book book = new Book();
            service.AddBook(book);

            Assert.That(repository.Books.First().Id, Is.Not.Null);
        }

        [Test]
        public void TestReturnAddBook()
        {
            Book book = new Book();
            var result = service.AddBook(book);

            Assert.That(result, Is.TypeOf<Book>());
        }
    }
}
