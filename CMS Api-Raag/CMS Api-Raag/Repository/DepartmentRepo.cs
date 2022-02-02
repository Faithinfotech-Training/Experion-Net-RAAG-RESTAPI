using CMS_Api_Raag.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_Api_Raag.Repository
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly CMSDBContext _context;
        public DepartmentRepo(CMSDBContext context)
        {
            _context = context;
        }


        //view all departments
        #region getDepartments
        public async Task<List<Department>> GetDepartments()
        {
            if (_context != null)
            {
                return await _context.Department.Include(d => d.Doctor).ToListAsync();
            }
            return null;
        }
        #endregion


        //Add new Departments
        #region Add Departments
        public async Task<int> AddDepartment(Department department)
        {
            if (_context != null)
            {
                await _context.Department.AddAsync(department);
                await _context.SaveChangesAsync();
                return department.DepId;
            }
            return 0;
        }
        #endregion


        //Delete a department
        #region Delete
        public async Task<int> DeleteDepartment(int? id)
        {
            int result = 0;
            if (_context != null)
            {
                var dept = await _context.Department.FirstOrDefaultAsync(dep => dep.DepId == id);

                //check condition
                if (dept != null)
                {
                    //delete
                    _context.Department.Remove(dept);

                    //commit
                    result = await _context.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }
        #endregion
    }
}
