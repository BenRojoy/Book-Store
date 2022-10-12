using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Backend.Models
{
    public class OrderSQLImpl : IOrderRepository
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
        SqlCommand comm = new SqlCommand();
        public void AddOrder(Orders order, int orderId)
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            comm.CommandText = "insert into orders values (" + orderId + ", " + order.UserId + ", " + order.BookId + ", " + order.Quantity + ", "
                + order.AddressId + ", '" + date + "')";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }

        public void DeleteOrder(int orderId)
        {
            comm.CommandText = "delete from orders where orderid = " + orderId;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }

        public List<Orders> GetOrder()
        {
            List<Orders> list = new List<Orders>();
            comm.CommandText = "select * from orders o join book b on o.BookId = b.BookId order by date";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["OrderId"]);
                int userId = Convert.ToInt32(reader["UserId"]);
                int bookId = Convert.ToInt32(reader["BookId"]);
                int quantity = Convert.ToInt32(reader["Quantity"]);
                int addressId = Convert.ToInt32(reader["AddressId"]);
                string dateTime = reader["Date"].ToString();
                list.Add(new Orders(id, userId, bookId, quantity, addressId, dateTime));
            }
            conn.Close();
            return list;
        }
        public List<Orders> GetOrderByUser(int id)
        {
            List<Orders> list = new List<Orders>();
            comm.CommandText = "select OrderId, UserId, b.BookId, Title, Image, Price, Quantity, AddressId, Date " +
                "from orders o join book b on o.BookId = b.BookId where userid = " + id + " order by date";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int orderId = Convert.ToInt32(reader["OrderId"]);
                int userId = Convert.ToInt32(reader["UserId"]);
                int bookId = Convert.ToInt32(reader["BookId"]);
                string title = reader["Title"].ToString();
                string image = reader["Image"].ToString();
                double price = Convert.ToDouble(reader["Price"]);
                int quantity = Convert.ToInt32(reader["Quantity"]);
                int addressId = Convert.ToInt32(reader["AddressId"]);
                string dateTime = reader["Date"].ToString();
                list.Add(new Orders(orderId, userId, bookId, title, image, price, quantity, addressId, dateTime));
            }
            conn.Close();
            return list;
        }

        public int GetOrderId()
        {
            int id = 10000;
            comm.CommandText = "select max(orderid) max, count(*) count from orders having COUNT(*) > 0";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                if (reader.HasRows)
                {
                    id = Convert.ToInt32(reader["max"]) + 1;
                }
            }
            conn.Close();
            return id;
        }

        public void UpdateOrder(Orders order)
        {
            comm.CommandText = "update orders set userid = " + order.UserId + ", bookid = " + order.BookId +
                ", quantity = " + order.Quantity + " where orderid = " + order.OrderId;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }
    }
}