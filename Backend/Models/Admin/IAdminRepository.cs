using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models
{
    internal interface IAdminRepository
    {
        List<Admins> GetAdmins();
        void AddAdmin(Admins admin);
        void DeleteAdmin(int userId);
        void UpdateAdmin(Admins admin);
    }
}
