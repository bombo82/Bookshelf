﻿using Bookshelf.Services;
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
        public void Service_ShouldDelete_ABook()
        {
            Mock<IBookshelfRepository> repository = new Mock<IBookshelfRepository>();
            BookshelfService service = new BookshelfService(repository.Object);

            service.DeleteBook("1");

            repository.Verify(repo => repo.DeleteABook(It.Is<string>(id => id.Equals("1"))));
        }

        [Test]
        public void DeletedBook_ShouldReturnTheBook()
        {
            Mock<IBookshelfRepository> repository = new Mock<IBookshelfRepository>();
            BookshelfService service = new BookshelfService(repository.Object);
            Book expectedBook = new Book() { Id = "1" };
            
            repository.Setup(repo =>
            repo.DeleteABook("1"))
                .Returns(expectedBook);

            Book deletedBook = service.DeleteBook("1");

            Assert.That(deletedBook, Is.EqualTo(expectedBook));
        }
    }
}
