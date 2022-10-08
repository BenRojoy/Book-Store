using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models
{
    internal interface IUserRepository
    {
        List<Users> GetUsers();
        void AddUser(Users user);
        void DeleteUser(int userId);
        void UpdateUser(Users user);
        void AdminUpdateUser(int id, int status);

    }
}
