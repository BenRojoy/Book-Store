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
    public class WishlistController : ApiController
    {
        private IWishlistRepository repository;

        public WishlistController()
        {
            repository = new WishlistSQLImpl();
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var data = repository.GetWishlist();
            return Ok(data);
        }

        [HttpPost]
        public IHttpActionResult Add(Wishlist wishlist)
        {
            repository.AddWishlist(wishlist);
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            repository.DeleteWishlist(id);
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Update(Wishlist wishlist)
        {
            repository.UpdateWishlist(wishlist);
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult UpdateQty(int id, int qty)
        {
            repository.UpdateWishlistQty(id, qty);
            return Ok();
        }
    }
}
