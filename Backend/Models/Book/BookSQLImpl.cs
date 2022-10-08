using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Backend.Models
{
    public class BookSQLImpl : IBookRepository
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
        SqlCommand comm = new SqlCommand();

        public void AddBook(Book book)
        {
            comm.CommandText = "insert into book values (" + book.CategoryId + ", '" + book.Title + "', '" + book.Author +
                "', '" + book.ISBN + "', " + book.Year + ", " + book.Price + ", '" + book.Description + "', " +
                book.Position + ", " + book.Status + ", '" + book.Image + "')";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }

        public void DeleteBook(int BookId)
        {
            comm.CommandText = "delete from book where bookid = " + BookId;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }

        public List<Book> GetAllBooks()
        {
            List<Book> list = new List<Book>();
            comm.CommandText = "select * from book where status = 1 order by position";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while(reader.Read())
            {
                int bookId = Convert.ToInt32(reader["BookId"]);
                int catId = Convert.ToInt32(reader["CategoryId"]);
                string title = reader["Title"].ToString();
                string author = reader["Author"].ToString();
                string isbn = reader["ISBN"].ToString();
                int year = Convert.ToInt32(reader["Year"]);
                double price = Convert.ToDouble(reader["Price"]);
                string desc = reader["Description"].ToString();
                int pos = Convert.ToInt32(reader["Position"]);
                int status = Convert.ToInt32(reader["Status"]);
                string img = reader["Image"].ToString();
                list.Add(new Book(bookId, catId, title, author, isbn, year, price, desc, pos, status, img));
            }
            conn.Close();
            return list;
        }

        public List<Book> GetBookByCat(int catId)
        {
            List<Book> list = new List<Book>();
            comm.CommandText = "select * from book where categoryid = " + catId + " and status = 1 order by position";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int bookId = Convert.ToInt32(reader["BookId"]);
                string title = reader["Title"].ToString();
                string author = reader["Author"].ToString();
                string isbn = reader["ISBN"].ToString();
                int year = Convert.ToInt32(reader["Year"]);
                double price = Convert.ToDouble(reader["Price"]);
                string desc = reader["Description"].ToString();
                int pos = Convert.ToInt32(reader["Position"]);
                int status = Convert.ToInt32(reader["Status"]);
                string img = reader["Image"].ToString();
                list.Add(new Book(bookId, catId, title, author, isbn, year, price, desc, pos, status, img));
            }
            conn.Close();
            return list;
        }

        public Book GetBookById(int id)
        {
            Book book = new Book();
            comm.CommandText = "select * from book where bookid = " + id;
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                book.BookId = id;
                book.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                book.Title = reader["Title"].ToString();
                book.Author = reader["Author"].ToString();
                book.ISBN = reader["ISBN"].ToString();
                book.Year = Convert.ToInt32(reader["Year"]);
                book.Price = Convert.ToDouble(reader["Price"]);
                book.Description = reader["Description"].ToString();
                book.Position = Convert.ToInt32(reader["Position"]);
                book.Status = Convert.ToInt32(reader["Status"]);
                book.Image = reader["Image"].ToString();
            }
            conn.Close();
            return book;
        }

        public void UpdateBook(Book book)
        {
            comm.CommandText = "update book set categoryid = " + book.CategoryId + ", title = '" + book.Title + "', author = '" + 
                book.Author + "', isbn = '" + book.ISBN + "', year = " + book.Year + ", price = " + book.Price + ", description = '" + 
                book.Description + "', position = " + book.Position + ", status = " + book.Status + ", image = '" + 
                book.Image + "' where bookid = " + book.BookId;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }
    }
}