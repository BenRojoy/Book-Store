using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Backend.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class CouponController : ApiController
    {
        private ICouponRepository repository;

        public CouponController()
        {
            repository = new CouponSQLImpl();
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var data = repository.GetCoupon();
            return Ok(data);
        }

        [HttpPost]
        public IHttpActionResult Add(Coupon coupon)
        {
            repository.AddCoupon(coupon);
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            repository.DeleteCoupon(id);
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Update(Coupon coupon)
        {
            repository.UpdateCoupon(coupon);
            return Ok();
        }
    }
}
