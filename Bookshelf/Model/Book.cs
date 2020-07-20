using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookshelf.Model
{
    namespace Bookshelf.Models
    {
        public class Book
        {
            public string Id { get; set; }

            public string Title { get; set; }

            public decimal Price { get; set; }

            public string Category { get; set; }

            public string Author { get; set; }
        }
    }
}
