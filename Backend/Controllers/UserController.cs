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
    public class UserController : ApiController
    {
        private IUserRepository repository;

        public UserController()
        {
            repository = new UserSQLImpl();
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var data = repository.GetUsers();
            return Ok(data);
        }

        [HttpPost]
        public IHttpActionResult Add(Users user)
        {
            repository.AddUser(user);
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            repository.DeleteUser(id);
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Update(Users user)
        {
            repository.UpdateUser(user);
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult AdminUpdate(int id, int status)
        {
            repository.AdminUpdateUser(id, status);
            return Ok();
        }
    }
}
