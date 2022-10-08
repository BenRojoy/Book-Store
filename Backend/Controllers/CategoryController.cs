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
    public class CategoryController : ApiController
    {
        private ICategoryRepository repository;

        public CategoryController()
        {
            repository = new CategorySQLImpl();
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var data = repository.GetCategories();
            return Ok(data);
        }

        [HttpPost]
        public IHttpActionResult Add(Category category)
        {
            repository.AddCategory(category);
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Update(Category category)
        {
            repository.UpdateCategory(category);
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            repository.DeleteCategory(id);
            return Ok();
        }
    }
}
