using System;
using System.Collections.Generic;
using System.Linq;

namespace AppEF
{
    class Program
    {
        static void Main(string[] args)
        {
            var work = new WorkWithBD();
            string name = Console.ReadLine();
            string email = Console.ReadLine();
            work.Add(new User{Name = name, Email = email});
            work.PrintAll();
            Console.ReadLine();
        }
    }
}
