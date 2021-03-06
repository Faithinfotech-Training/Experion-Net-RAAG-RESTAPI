using CMS_Api_Raag.Models;
using CMS_Api_Raag.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_Api_Raag.Repository
{
    public class EmployeeRepo : IEmployeeRepo
    {

        private readonly CMSDBContext _context;
        public EmployeeRepo(CMSDBContext context)
        {
            _context = context;
        }

        //Viewing all employee details
        #region GetEmployees
        public async Task<List<Employee>> GetEmployees()
        {
            if (_context != null)
            {
                return await _context.Employee.Include(a => a.Admin).Include(d => d.Doctor).Include(r => r.Role).ToListAsync();
            }
            return null;
        }
        #endregion

        //Viewing all doctor details
        #region Getdoctors
        public async Task<List<Doctor>> GetallDoctors()
        {
            if (_context != null)
            {
                return await _context.Doctor.ToListAsync();
            }
            return null;
        }
        #endregion


        //For Adding new Employee
        #region AddEmployee
        public async Task<int> AddEmployee(Employee employee)
        {
            if (_context != null)
            {
                await _context.Employee.AddAsync(employee);
                await _context.SaveChangesAsync();
                return employee.EmployeeId;
            }
            return 0;
        }
        #endregion

        //For Adding new doctor
        #region AddDoctor
        public async Task<int> AddDoctor(Doctor employee)
        {
            if (_context != null)
            {
                await _context.Doctor.AddAsync(employee);
                await _context.SaveChangesAsync();
                return employee.DoctorId;
            }
            return 0;
        }
        #endregion


        //updating Employee details
        #region UpdateEmployee
        public async Task UpdateEmployee(Employee employee)
        {

            if (_context != null)
            {
                _context.Entry(employee).State = EntityState.Modified;
                _context.Employee.Update(employee);
                await _context.SaveChangesAsync();
            }
        }
        #endregion

        //update doctor
        #region doctor updates
        public  async Task UpdateDoctor(Doctor employee)
        {
            if (_context != null)
            {
                _context.Entry(employee).State = EntityState.Modified;
                _context.Doctor.Update(employee);
                await _context.SaveChangesAsync();
            }
        }
        #endregion


        //Deleting an Employee details
        #region DeleteEmployee
        public async Task<int> DeleteEmployee(int? id)
        {
            //declare variable
            int result = 0;
            if (_context != null)
            {                                                                
                var employee = await _context.Employee.FirstOrDefaultAsync(emp => emp.EmployeeId == id);

                //check condition
                if (employee != null)
                {
                    //delete
                    _context.Employee.Remove(employee);

                    //commit
                    result = await _context.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }

        #endregion

        //get employee details using id
        #region Get by Id
        public async Task<ActionResult<Employee>> GetEmployeeById(int? id)
        {
            if (_context != null)
            {
                return await _context.Employee.FindAsync(id);

            }
            return null;
        }
        #endregion


        #region emp by ph
        public async Task<IEnumerable<Employee>> GetEmpPh(string ph)
        {
            IQueryable<Employee> query = _context.Employee;
            if (!string.IsNullOrEmpty(ph))
            {
                query = query.Where(e => e.PhoneNumber.Contains(ph));
            }
            return await query.ToListAsync();
        }
        #endregion

        #region emp by username
        public  async Task<IEnumerable<Employee>> GetEmpUname(string uName)
        {
            IQueryable<Employee> query = _context.Employee;
            if (!string.IsNullOrEmpty(uName))
            {
                query = query.Where(e => e.UserName.Contains(uName));
            }
            return await query.ToListAsync();
        }
        #endregion


        //view Admin details
        #region admin details
        public async Task<List<AdminViewModel>> GetAdmins()
        {
            if (_context != null)
            {
                return await (from e in _context.Employee
                              from a in _context.Admin
                              where e.EmployeeId == a.EmployeeId
                              select new AdminViewModel
                              {
                                  AdminId = a.AdminId,
                                  EmployeeId = e.EmployeeId,
                                  UserName = a.UserName,
                                  FirstName = e.FirstName,
                                  LastName = e.LastName,
                                  Dob = e.Dob,
                                  PhoneNumber = e.PhoneNumber,
                                  EmailAddress = e.EmailAddress,
                                  Gender = e.Gender,
                                  Address = e.Address,
                                  Password = e.Password,
                                  Doj = e.Doj,
                                  EmployeeStatus = e.EmployeeStatus
                              }
                              ).ToListAsync();

            }
            return null;
        }
        #endregion


       // view Doctor details
        #region Get Doctors
        public async Task<List<DoctorListViewModel>> GetDoctors()
        {
            if (_context != null)
            {
                return await (from e in _context.Employee
                              from d in _context.Doctor
                              from f in _context.Department
                              where e.EmployeeId == d.EmployeeId && d.DepId == f.DepId
                              select new DoctorListViewModel
                              {
                                  DoctorId = d.DoctorId,
                                  EmployeeId = e.EmployeeId,
                                  FirstName = e.FirstName,
                                  DepId = d.DepId,
                                  DepName = f.DepName

                              }
                              ).ToListAsync();

            }
            return null;
        }
        #endregion


        //View All Employee details
        #region  GET All employees
        public async Task<List<EmployeeViewModel>> GetAllEmployees()
        {
            if (_context != null)
            {
                return await (from e in _context.Employee
                              from r in _context.Role
                              where e.RoleId == r.RoleId
                              select new EmployeeViewModel
                              {
                                  EmployeeId = e.EmployeeId,
                                  FirstName = e.FirstName,
                                  LastName = e.LastName,
                                  Dob = e.Dob,
                                  PhoneNumber = e.PhoneNumber,
                                  EmailAddress = e.EmailAddress,
                                  Gender = e.Gender,
                                  Address = e.Address,
                                  Password = e.Password,
                                  Doj = e.Doj,
                                  EmployeeStatus = e.EmployeeStatus,
                                  RoleName = r.RoleName

                              }
                              ).ToListAsync();

            }
            return null;
        }
        #endregion







    }
}
