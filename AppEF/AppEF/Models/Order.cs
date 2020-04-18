using System;
using System.Collections.Generic;
using System.Text;

namespace AppEF
{
    class Order
    {
        public int Id { get; set; }
        public User Customer { get; set; }
        public List<Book> Books { get; set; }
    }
}
