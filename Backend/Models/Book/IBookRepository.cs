using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models
{
    internal interface IBookRepository
    {
        List<Book> GetAllBooks();
        List<Book> GetBookByCat(int catId);
        Book GetBookById(int id);
        void AddBook(Book book);
        void DeleteBook(int BookId);
        void UpdateBook(Book book);
    }
}
