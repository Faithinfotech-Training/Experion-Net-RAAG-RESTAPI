using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS_Api_Raag.Models;
using CMS_Api_Raag.ViewModel;

namespace CMS_Api_Raag.Repository
{
    public interface IUserRepository
    {

        //get all user ---view model
        Task<List<UserViewModel>> GetAllUser();


        //Get all Users with roles
        Task<List<Employee>> GetUsers();

        //Find a user with name and password

        Task<Employee> GetUserByNameandPasswords(string name, string password);



    }
}
