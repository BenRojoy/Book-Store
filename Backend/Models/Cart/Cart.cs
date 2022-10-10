using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public Cart(int cartId, int bookId, string title, string image, double price, int quantity)
        {
            CartId = cartId;
            BookId = bookId;
            Title = title;
            Image = image;
            Price = price;
            Quantity = quantity;
        }
    }
}