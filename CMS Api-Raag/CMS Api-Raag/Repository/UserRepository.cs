using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS_Api_Raag.Models;
using CMS_Api_Raag.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace CMS_Api_Raag.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly CMSDBContext _context1;
        public UserRepository(CMSDBContext context1)
        {
            _context1 = context1;
        }


        #region get user by Name and password
        public async Task<Employee> GetUserByNameandPasswords(string name, string password)
        {

            Employee result = await _context1.Employee.Where(x => x.UserName == name && x.Password == password).FirstAsync();
            return result;

        }
        #endregion



        #region users with roles
        //Method to get all users with roles
        public async Task<List<Employee>> GetUsers()
        {
            if (_context1 != null)
            {                 
                return await _context1.Employee.Include(p => p.Role).ToListAsync();
            }
            return null;
        }
        #endregion



        #region Get all users -- view Model
        public async Task<List<UserViewModel>> GetAllUser()
        {
            if (_context1 != null)
            {
                //LINQ
                //join post and category
                return await (from u in _context1.Employee
                              from r in _context1.Role
                              where u.RoleId == r.RoleId
                              select new UserViewModel
                              {
                                  UserName = u.UserName,
                                  Password = u.Password,
                                  RoleName = r.RoleName
                              }
                              ).ToListAsync();
            }
            return null;
        }
        #endregion

    }
}
