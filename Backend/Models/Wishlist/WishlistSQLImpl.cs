﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Backend.Models
{
    public class WishlistSQLImpl : IWishlistRepository
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
        SqlCommand comm = new SqlCommand();
        public void AddWishlist(Wishlist wishlist)
        {
            comm.CommandText = "insert into wishlist values (" + wishlist.UserId + ", " + wishlist.BookId+ ", " + wishlist.Quantity + ")";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }

        public void DeleteWishlist(int wishlistId)
        {
            comm.CommandText = "delete from wishlist where wishlistid = " + wishlistId;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }

        public List<Wishlist> GetByUser(int userId)
        {
            List<Wishlist> list = new List<Wishlist>();
            comm.CommandText = "select WishlistId, b.BookId, Title, Image, Price, Quantity from wishlist w join book b on w.bookid = b.bookid where userid = " + userId;
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int wishlistId = Convert.ToInt32(reader["WishlistId"]);
                int bookId = Convert.ToInt32(reader["BookId"]);
                string title = reader["Title"].ToString();
                string image = reader["Image"].ToString();
                double price = Convert.ToDouble(reader["Price"]);
                int quantity = Convert.ToInt32(reader["Quantity"]);
                list.Add(new Wishlist(wishlistId, bookId, title, image, price, quantity));
            }
            conn.Close();
            return list;
        }

        public void UpdateWishlist(Wishlist wishlist)
        {
            comm.CommandText = "update wishlist set userid = " + wishlist.UserId + ", bookid = " + wishlist.BookId + 
                ", quantity = " + wishlist.Quantity + " where wishlistid = " + wishlist.WishlistId;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }
        public void UpdateWishlistQty(int id, int qty)
        {
            comm.CommandText = "update wishlist set quantity = " + qty + " where wishlistid = " + id;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }
    }
}