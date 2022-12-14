using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Models
{
    public class Admins
    {
        public int AdminId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Int64 Mobile { get; set; }

        public Admins(int adminId, string name, string username, string password, string email,
            long mobile)
        {
            AdminId = adminId;
            Name = name;
            Username = username;
            Password = password;
            Email = email;
            Mobile = mobile;
        }
    }

}
