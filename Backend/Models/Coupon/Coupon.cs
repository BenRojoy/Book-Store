using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Models
{
    public class Coupon
    {
        public int CouponId { get; set; }
        public string Title { get; set; }
        public double MinCartValue { get; set; }
        public double Discount { get; set; }
        public Coupon(int couponId, string title, double minCartValue, double discount)
        {
            CouponId = couponId;
            Title = title;
            MinCartValue = minCartValue;
            Discount = discount;
        }
    }
}