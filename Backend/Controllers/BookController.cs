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
    public class BookController : ApiController
    {
        private IBookRepository repository;

        public BookController()
        {
            repository = new BookSQLImpl();
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var data = repository.GetAllBooks();
            return Ok(data);
        }

        [HttpGet]
        public IHttpActionResult GetByCatId(int id)
        {
            var data = repository.GetBookByCat(id);
            return Ok(data);
        }

        [HttpGet]
        public IHttpActionResult GetById(int x, int id)
        {
            var data = repository.GetBookById(id);
            return Ok(data);
        }

        [HttpPost]
        public IHttpActionResult Add(Book book)
        {
            repository.AddBook(book);
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Update(Book book)
        {
            repository.UpdateBook(book);
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            repository.DeleteBook(id);
            return Ok();
        }
    }
}
