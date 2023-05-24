using ConsoleApp1.Business_Layer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program               
    {
        public static readonly CRUD_Operations operation = CRUD_Operations.Instance;
        static void Main(string[] args)
        {

            Console.WriteLine("Enter a book Id to find the book name: ");
            var bookId = Convert.ToInt32(Console.ReadLine());
            var result2 = operation.GetBook(bookId);

            if (result2 != null)
                Console.WriteLine(result2);

            else
                Console.WriteLine("Book not found!");


            Console.WriteLine("\nInsert a book started");
            Book book = new Book();
            book.Name = "New Book";
            book.Pages = 200;
            book.Publish_Date = DateTime.Now;
            book.Auther_Id = 1;
            var insertResult = operation.AddBook(book);

            if (insertResult > 0)
                Console.WriteLine("Book inserted successfully");

            var result = operation.GetList();
            Console.WriteLine("\nBooks list: ");
            foreach (var item in result)
            {
                Console.WriteLine(item.Id + "\t" + item.Name + "\t" + item.Pages);
            }


            Console.WriteLine("Database has been closed");

            Console.ReadLine();




        }

    }

    }
