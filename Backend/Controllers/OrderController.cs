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
    public class OrderController : ApiController
    {
        private IOrderRepository repository;

        public OrderController()
        {
            repository = new OrderSQLImpl();
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var data = repository.GetOrder();
            return Ok(data);
        }

        [HttpPost]
        public IHttpActionResult Add(Orders order)
        {
            int orderId = repository.GetOrderId();
            repository.AddOrder(order, orderId);
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            repository.DeleteOrder(id);
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Update(Orders order)
        {
            repository.UpdateOrder(order);
            return Ok();
        }
    }
}
