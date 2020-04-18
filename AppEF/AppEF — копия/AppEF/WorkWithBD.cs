using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppEF
{
    class WorkWithBD
    {
        public void PrintAll()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // получаем объекты из бд и выводим на консоль
                Console.WriteLine("Все пользователи:");
                foreach (User u in db.Users.ToList())
                {
                    Console.WriteLine($"{u.Id} {u.Name} {u.Email}");
                }

                Console.WriteLine("Все авторы:");
                foreach (Author u in db.Authors.ToList())
                {
                    Console.WriteLine($"{u.Name}");
                }

                Console.WriteLine("Все книги:");
                foreach (Book u in db.Books.ToList())
                {
                    Console.WriteLine($"{u.Name} {u.AuthorOfThisBook.Name}");
                }

                Console.WriteLine("Все заказы:");
                foreach (Order u in db.Orders.ToList())
                {
                    Console.WriteLine($"{u.Customer.Name}");
                    for(int i = 0; i < u.Books.Count; i++)
                        Console.Write(u.Books[i].Name);
                }
            }
        }
        public void Add(User user)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public void Add(Author author)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Authors.Add(author);
                db.SaveChanges();
            }
        }

        public void Add(Book book)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Books.Add(book);
                //добавляем книгу в лист книг данного автора
                foreach (Author u in db.Authors.ToList())
                {
                    //ищем в бд автора с данным именем
                    if (u.Name == book.AuthorOfThisBook.Name)
                        u.Books.Add(book);
                    //если не находим, создаем нового автора и добавляем в его лист книг данную книгу
                    else
                        db.Authors.Add(new Author {Name = book.AuthorOfThisBook.Name, Books = new List<Book>{book}});
                }
                db.SaveChanges();
            }
        }

        public void Add(Order order)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Orders.Add(order);
                db.SaveChanges();
            }
        }
    }
}
