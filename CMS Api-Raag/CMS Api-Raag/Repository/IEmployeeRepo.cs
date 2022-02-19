using CMS_Api_Raag.Models;
using CMS_Api_Raag.ViewModel;
using Microsoft.AspNetCore.Mvc;
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

        //view All doctors
        Task<List<Doctor>> GetallDoctors();

        //For adding new Employee
        Task<int> AddEmployee(Employee employee);

        //adding doctor
        Task<int> AddDoctor(Doctor employee);

        //Updating Employee details
        Task UpdateEmployee(Employee employee);

        //Deleting an Employee details
        Task<int> DeleteEmployee(int? id);

        //search employee by id
        Task<ActionResult<Employee>> GetEmployeeById(int? id);

        //find employee by phone number   
        Task<IEnumerable<Employee>> GetEmpPh(string ph);


        //view Admin details ----ViewModel
        Task<List<AdminViewModel>> GetAdmins();

        //View Doctor Details  ---ViewModel
        Task<List<DoctorListViewModel>> GetDoctors();

        //View Employee Details   ---viewModel
        Task<List<EmployeeViewModel>> GetAllEmployees();


    }
}
