﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models
{
    internal interface ICartRepository
    {
        List<Cart> GetCartUser(int id);
        void AddCart(Cart cart);
        void DeleteCart(int cartId);
        void UpdateCart(Cart cart);
        void UpdateCartQty(int id, int qty);

    }
}
