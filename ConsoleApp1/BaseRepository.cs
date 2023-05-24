using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    // class that doesn't change no matter what 
    public class BaseRepository
    {
        private readonly string connectionString;

        protected BaseRepository ()
        {
            connectionString = ConfigurationManager.ConnectionStrings["TestTuwaiq"].ConnectionString; // connection injection 
        }

        protected SqlConnection GetConnection()
        {
            var result = new SqlConnection(connectionString);
            return result;
        }
        public string GetBook(SqlCommand command, SqlConnection connection)
        {
            try
            {
                connection.Open();
                var book = (string) command.ExecuteScalar();
                return book;
            }
            finally
            {
                connection.Close();
            }
        }
        public int AddBook(SqlCommand command, SqlConnection connection)
        {
            try
            {
                connection.Open();
                var result = (int)command.ExecuteNonQuery();
                return result;
            }
            finally
            {
                connection.Close();
            }
        }
        public List<Book> GetBooks(SqlCommand command , SqlConnection connection)
        {
            var list = new List<Book>();
            try
            {
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())       // acts as a mapper could be in different method
                {
                    var book = new Book(); // to map batween book table and book model

                    book.Id = Convert.ToInt32(reader[0]);
                    book.Name = reader[1].ToString();
                    book.Pages = Convert.ToInt32(reader[2]);

                    list.Add(book);
                }


                return list;
            }
            finally
            {
                connection.Close();
            }
        }

    }
}
