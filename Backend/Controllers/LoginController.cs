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
    public class LoginController : ApiController
    {
        private ILoginRepository repository;

        public LoginController()
        {
            repository = new LoginSQLImpl();
        }

        [HttpPost]
        public IHttpActionResult Post(Login login)
        {
            string[] data = repository.UserLogin(login);
            return Ok(data);
        }
    }
}
