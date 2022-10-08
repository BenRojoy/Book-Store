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
    public class AdminController : ApiController
    {
        private IAdminRepository repository;

        public AdminController()
        {
            repository = new AdminSQLImpl();
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var data = repository.GetAdmins();
            return Ok(data);
        }

        [HttpPost]
        public IHttpActionResult Add(Admins admin)
        {
            repository.AddAdmin(admin);
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            repository.DeleteAdmin(id);
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Update(Admins admin)
        {
            repository.UpdateAdmin(admin);
            return Ok();
        }
    }
}
