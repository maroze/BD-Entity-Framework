using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Product product1 = new Product { Type = "Phone", Cost = 20000 };
                Product product2 = new Product { Type = "Notebook", Cost = 50000 };

                // Добавление
                db.Products.AddRange(product1, product2);
                db.SaveChanges();
            }

            // получение
            using (ApplicationContext db = new ApplicationContext())
            {
            
                var products = db.Products.ToList();
                Console.WriteLine("Данные после добавления:");
                foreach (Product p in products)
                {
                    Console.WriteLine($"{p.Id}.{p.Type} - {p.Cost} руб");
                }
            }

            // Редактирование
            using (ApplicationContext db = new ApplicationContext())
            {
                
                Product product = db.Products.FirstOrDefault();

                if (product != null)
                {
                    product.Type = "Printer";
                    product.Cost = 54000;
                    db.Products.Update(product);
                    db.SaveChanges();
                }
               
                Console.WriteLine("\nДанные после редактирования:");
                var products = db.Products.ToList();
                foreach (Product p in products)
                {
                    Console.WriteLine($"{p.Id}.{p.Type} - {p.Cost} руб");
                }
            }

            // Удаление
            using (ApplicationContext db = new ApplicationContext())
            {
                
                Product product = db.Products.FirstOrDefault();
               
                if (product != null)
                {
                   
                    db.Products.Remove(product);
                    db.SaveChanges();
                }
               
                Console.WriteLine("\nДанные после удаления:");
                var products = db.Products.ToList();
                foreach (Product p in products)
                {
                    Console.WriteLine($"{p.Id}.{p.Type} - {p.Cost} руб");
                }
            }
            Console.Read();
        }
    }
}
