using System.Collections.Generic;
using System.Linq;
using CMS_Api_Raag.Models;

namespace CMS_Api_Raag.Services
{
    public class UserService : IUserService
    {
        private CMSDBContext _context;

        public UserService(CMSDBContext context)
        {
            _context = context;
        }

        public Employee Authenticate(string emailaddress, string password)
        {
            if (string.IsNullOrEmpty(emailaddress) || string.IsNullOrEmpty(password))
                return null;

            var user = _context.Employee.SingleOrDefault(x => x.EmailAddress == emailaddress);

            // check if username exists
            if (user == null)
                return null;

            // authentication successful
            return user;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employee;
        }

        public Employee GetById(int id)
        {
            return _context.Employee.Find(id);
        }

        public Employee Create(Employee user, string password)
        {
            _context.Employee.Add(user);
            _context.SaveChanges();

            return user;
        }

        public void Update(Employee userParam, string password = null)
        {
            var user = _context.Employee.Find(userParam.EmailAddress);

            // update username if it has changed
            if (!string.IsNullOrWhiteSpace(userParam.EmailAddress) && userParam.EmailAddress != user.EmailAddress)
            {
                // throw error if the new username is already taken
                if (_context.Employee.Any(x => x.EmailAddress == userParam.EmailAddress))
                {
                   
                }

                user.EmailAddress = userParam.EmailAddress;
            }

            // update user properties if provided
            if (!string.IsNullOrWhiteSpace(userParam.FirstName))
                user.FirstName = userParam.FirstName;

            if (!string.IsNullOrWhiteSpace(userParam.LastName))
                user.LastName = userParam.LastName;

            _context.Employee.Update(user);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = _context.Employee.Find(id);
            if (user != null)
            {
                _context.Employee.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}
