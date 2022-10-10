using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Models
{
    public class Wishlist
    {
        public int WishlistId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public Wishlist(int wishlistId, int bookId, string title, string image, double price, int quantity)
        {
            WishlistId = wishlistId;
            BookId = bookId;
            Title = title;
            Image = image;
            Price = price;
            Quantity = quantity;
        }
    }
}