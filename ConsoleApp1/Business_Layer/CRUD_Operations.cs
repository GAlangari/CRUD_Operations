using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ConsoleApp1.Business_Layer 
{
    public class CRUD_Operations : BaseRepository
    {
        public static readonly CRUD_Operations Instance = new CRUD_Operations();     // to be able to use it anywhere in the solution or outside of it
        public List<Book> GetList()
        {
            var con = GetConnection();
            var query = "SELECT * FROM Book";

            var cmd = new SqlCommand(query, con);

            var result = GetBooks(cmd, con);

            return result;
        }
        public string GetBook (int bookId)
        {
            var con = GetConnection();
            var query = "SELECT Name FROM Book WHERE Id = " + bookId;


            var cmd = new SqlCommand(query, con);
            var result = GetBook(cmd, con);

            return result;
        }
        public int AddBook(Book book)
        {
            var con = GetConnection();
            var query = "INSERT INTO Book ([name], [pages], [Publish_Date], [Auther_Id]) " +
                "VALUES (@Name, @Pages, @Publish_Date, @Auther_Id)";


            var cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("name", book.Name);
            cmd.Parameters.AddWithValue("pages", book.Pages);
            cmd.Parameters.AddWithValue("publish_Date", book.Publish_Date);
            cmd.Parameters.AddWithValue("Auther_Id", book.Auther_Id);

            var result = AddBook(cmd, con);

            return result;
        }
    }
}
