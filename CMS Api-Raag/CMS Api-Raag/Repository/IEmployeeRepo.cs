using CMS_Api_Raag.Models;
using CMS_Api_Raag.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_Api_Raag.Repository
{
    public interface IEmployeeRepo
    {
        //view All Employees
        Task<List<Employee>> GetEmployees();

        //For adding new Employee
        Task<int> AddEmployee(Employee employee);

        //Updating Employee details
        Task UpdateEmployee(Employee employee);

        //Deleting an Employee details
        Task<int> DeleteEmployee(int? id);


        //view Admin details ----ViewModel
        Task<List<AdminViewModel>> GetAdmins();

        //View Doctor Details  ---ViewModel
        Task<List<DoctorListViewModel>> GetDoctors();

        //View Employee Details   ---viewModel
        Task<List<EmployeeViewModel>> GetAllEmployees();


    }
}
