using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS_Api_Raag.Models;

namespace CMS_Api_Raag.Services
{
   public interface IUserService
    {
        Employee Authenticate(string username, string password);
        IEnumerable<Employee> GetAll();
        Employee GetById(int id);
        Employee Create(Employee user, string password);

    }
}
