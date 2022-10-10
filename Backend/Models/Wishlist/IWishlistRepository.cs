using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models
{
    internal interface IWishlistRepository
    {
        List<Wishlist> GetByUser(int id);
        void AddWishlist(Wishlist wishlist);
        void DeleteWishlist(int wishlistId);
        void UpdateWishlist(Wishlist wishlist);
        void UpdateWishlistQty(int id, int qty);
    }
}
