using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models
{
    internal interface ILoginRepository
    {
        string[] UserLogin(Login login);
    }
}
