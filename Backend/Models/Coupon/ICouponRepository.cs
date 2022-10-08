using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models
{
    internal interface ICouponRepository
    {
        List<Coupon> GetCoupon();
        void AddCoupon(Coupon coupon);
        void DeleteCoupon(int couponId);
        void UpdateCoupon(Coupon coupon);
    }
}
