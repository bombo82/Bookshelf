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

        [Test]
        public void TestListOfBooks() 
        {
            var result = service.GetBooks();

            Assert.That(result, Has.Count.EqualTo(2));
        }

        [Test]
        public void TestGetBook()
        {
            Book result = service.GetBook("1");
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo("1"));
        }

        [Test]
        public void BookAdded_ShouldHaveUniqueId()
        {
            Book bookToAdd = new Book();
            Book bookToAdd2 = new Book();
            Book addedBook = service.AddBook(bookToAdd);
            Book addedBook2 = service.AddBook(bookToAdd2);

            Assert.That(addedBook.Id, Is.Not.EqualTo(addedBook2.Id));
        }

        [Test]
        public void GetBookById_ShouldRetunNullWhenNotFound()
        {
            Book bookToAdd = new Book();
            Book bookToAdd2 = new Book();
            Book addedBook = service.AddBook(bookToAdd);
            Book addedBook2 = service.AddBook(bookToAdd2);

            Book book = service.GetBook("5");

            Assert.That(book, Is.Null);
        }
    }
}
