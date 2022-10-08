using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Models
{
    public class Login
    {
        public string Type { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}