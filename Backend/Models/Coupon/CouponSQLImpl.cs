using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Backend.Models
{
    public class CouponSQLImpl : ICouponRepository
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
        SqlCommand comm = new SqlCommand();
        public void AddCoupon(Coupon coupon)
        {
            comm.CommandText = "insert into coupon values ('" + coupon.Title + "', " + coupon.MinCartValue+ ", " + coupon.Discount+ ")";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }

        public void DeleteCoupon(int couponId)
        {
            comm.CommandText = "delete from coupon where couponid = " + couponId;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }

        public List<Coupon> GetCoupon()
        {
            List<Coupon> list = new List<Coupon>();
            comm.CommandText = "select * from coupon";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["CouponId"]);
                string title = reader["Title"].ToString();
                int cartValue = Convert.ToInt32(reader["MinCartValue"]);
                int discount = Convert.ToInt32(reader["Discount"]);
                list.Add(new Coupon(id, title, cartValue, discount));
            }
            conn.Close();
            return list;
        }

        public void UpdateCoupon(Coupon coupon)
        {
            comm.CommandText = "update coupon set title = '" + coupon.Title + "', mincartvalue = " + coupon.MinCartValue 
                + ", discount = " + coupon.Discount + " where couponid = " + coupon.CouponId;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }
    }
}