using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Models
{
    public class Orders
    {
     
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int AddressId { get; set; }
        public string Date { get; set; }
        public Orders(int orderId, int userId, int bookId, int quantity, int addressId, string date)
        {
            OrderId = orderId;
            UserId = userId;
            BookId = bookId;
            Quantity = quantity;
            AddressId = addressId;
            Date = date;
        }

        public Orders(int orderId, int userId, int bookId, string title, string image, double price, int quantity, int addressId, string date)
        {
            OrderId = orderId;
            UserId = userId;
            BookId = bookId;
            Title = title;
            Image = image;
            Price = price;
            Quantity = quantity;
            AddressId = addressId;
            Date = date;
        }
    }
}