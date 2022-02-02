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
    public class DeparmentsController : ControllerBase
    {
        private readonly IDepartmentRepo _depRepo;
        public DeparmentsController(IDepartmentRepo depRepo)
        {
            _depRepo = depRepo;
        }

        //view Departments
        #region Get Departments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
        {
            return await _depRepo.GetDepartments();
        }
        #endregion


        //Adding new Department
        #region Add Department
        [HttpPost]
        public async Task<IActionResult> AddDepartment([FromBody] Department department)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var depId = await _depRepo.AddDepartment(department);
                    if (depId > 0)
                    {
                        return Ok(depId);
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


        //Delete Department
        #region Delete department           
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int? id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                result = await _depRepo.DeleteDepartment(id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

    }
}
