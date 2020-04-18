using System;
using System.Collections.Generic;
using System.Text;

namespace AppEF
{
    class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Author AuthorOfThisBook { get; set; }
    }
}
