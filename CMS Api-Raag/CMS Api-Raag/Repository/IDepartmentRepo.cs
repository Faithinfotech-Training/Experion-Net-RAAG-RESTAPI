using CMS_Api_Raag.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_Api_Raag.Repository
{
   public interface IDepartmentRepo
    {
        //view all departments
        Task<List<Department>> GetDepartments();

        //Add new Departments
        Task<int> AddDepartment(Department department);

        //delete a department
        Task<int> DeleteDepartment(int? id);
    }
}
