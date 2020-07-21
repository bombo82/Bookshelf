﻿using Bookshelf.Model.Bookshelf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookshelf.Repositories
{
    public interface IBookshelfRepository
    {
        void AddABook(Book bookToAdd);
    }
}