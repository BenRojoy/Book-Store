using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Backend.Models
{
    public class CartSQLImpl : ICartRepository
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
        SqlCommand comm = new SqlCommand();
        public void AddCart(Cart cart)
        {
            comm.CommandText = "insert into cart values (" + cart.UserId + ", " + cart.BookId + ", " + cart.Quantity + ")";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }

        public void DeleteCart(int cartId)
        {
            comm.CommandText = "delete from cart where cartid = " + cartId;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }

        public List<Cart> GetCartUser(int userId)
        {
            List<Cart> list = new List<Cart>();
            comm.CommandText = "select CartId, b.BookId, Title, Image, Price, Quantity from cart c join book b on c.bookid = b.bookid where userid = " + userId;
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int cartId = Convert.ToInt32(reader["CartId"]);
                int bookId = Convert.ToInt32(reader["BookId"]);
                string title = reader["Title"].ToString();
                string image = reader["Image"].ToString();
                double price = Convert.ToDouble(reader["Price"]);
                int quantity = Convert.ToInt32(reader["Quantity"]);
                list.Add(new Cart(cartId, bookId, title, image, price, quantity));
            }
            conn.Close();
            return list;
        }

        public void UpdateCart(Cart cart)
        {
            comm.CommandText = "update cart set userid = " + cart.UserId + ", bookid = " + cart.BookId +
                ", quantity = " + cart.Quantity + " where cartid = " + cart.CartId;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }
        public void UpdateCartQty(int id, int qty)
        {
            comm.CommandText = "update cart set quantity = " + qty + " where cartid = " + id;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }
    }
}