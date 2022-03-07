using CMS_Api_Raag.Models;
using CMS_Api_Raag.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_Api_Raag.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        private readonly IEmployeeRepo _empRepo;
        public EmployeesController(IEmployeeRepo empRepo)
        {
            _empRepo = empRepo;
        }

        //viewing all Employee details
        #region GetEmployees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await _empRepo.GetEmployees();
        }
        #endregion


        //viewing allDoctor details
        #region GetDoctor
        [HttpGet]
        [Route("GetDoctor")]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetallDoctor()
        {
            return await _empRepo.GetallDoctors();
        }
        #endregion


        //Adding new Employee
        #region AddEmployee
        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var employeeId = await _empRepo.AddEmployee(employee);
                    if (employeeId > 0)
                    {
                        return Ok(employeeId);
                    }
                    else
                    {
                        return NotFound();
                    }

                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        //Adding new doctor
        #region AddDoctor
        [HttpPost]
        [Route("GetDoctor")]
        public async Task<IActionResult> AddDoctor([FromBody] Doctor employee)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var drId = await _empRepo.AddDoctor(employee);
                    if (drId > 0)
                    {
                        return Ok(drId);
                    }
                    else
                    {
                        return NotFound();
                    }

                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion


        //Update an Employee
        #region Update Employee
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromBody] Employee employee)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await _empRepo.UpdateEmployee(employee);
                    return Ok();

                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        #region doctor update
        [HttpPut]
        [Route("GetDoctor")]
        public async Task<IActionResult> UpdateDoctor([FromBody] Doctor employee)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await _empRepo.UpdateDoctor(employee);
                    return Ok();

                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion


        //Delete employee Details
        #region Delete Employee             
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeById(int? id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                result = await _empRepo.DeleteEmployee(id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok(); //retrun ok(employee)
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion


        //Get employee details using Id
        #region GEt By Id
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeetById(int? id)
        {
            try
            {
                ActionResult<Employee> employee = await _empRepo.GetEmployeeById(id);
                if (employee == null)
                {
                    return NotFound();
                }
                return employee;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion


        #region Get By phone
        [HttpGet("{search}/{ph}")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmpPh(string ph)
        {
            try
            {
                var employee = await _empRepo.GetEmpPh(ph);
                if (employee == null)
                {
                    return NotFound();
                }
                return Ok(employee);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region Get By User Name
        [HttpGet("{search}/{empuname}/{uName}")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmpUname(string uName)
        {
            try
            {
                var staff = await _empRepo.GetEmpUname(uName);
                if (staff == null)
                {
                    return NotFound();
                }
                return Ok(staff);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        //view Admin details
        #region GETAdmin
        [HttpGet]
        [Route("GetAdminDetails")]
        public async Task<IActionResult> GeAdminDetails()
        {
            try
            {
                var emp = await _empRepo.GetAdmins();
                if (emp == null)
                {
                    return NotFound();
                }
                return Ok(emp);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion


        //view Doctor details
        #region GETDoctor
        [HttpGet]
        [Route("GetDoctorDetails")]
        public async Task<IActionResult> GetDoctorDetails()
        {
            try
            {
                var emp = await _empRepo.GetDoctors();
                if (emp == null)
                {
                    return NotFound();
                }
                return Ok(emp);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion


        //view Employee details
        #region GETAllEmployees
        [HttpGet]
        [Route("GetEmployeeDetails")]
        public async Task<IActionResult> GetEmployeeDetails()
        {
            try
            {
                var emp = await _empRepo.GetAllEmployees();
                if (emp == null)
                {
                    return NotFound();
                }
                return Ok(emp);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion
    }
}
