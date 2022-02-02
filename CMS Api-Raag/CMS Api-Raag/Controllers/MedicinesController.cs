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
    public class MedicinesController : ControllerBase
    {
        private readonly IMedicineRepo _mediRepo;
        public MedicinesController(IMedicineRepo mediRepo)
        {
            _mediRepo = mediRepo;
        }

        //view Medicines
        #region Get Medicines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medicine>>> GetMedicines()
        {
            return await _mediRepo.GetMedicines();
        }
        #endregion


        //view Medicines  --viewModel
        #region GETPosts
        [HttpGet]
        [Route("GetMedicines")]
        public async Task<IActionResult> GePosts()
        {
            try
            {
                var medi = await _mediRepo.GetAllMedicines();
                if (medi == null)
                {
                    return NotFound();
                }
                return Ok(medi);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion


        //view medicines using medicineNames  --viewModel
        #region GET user by name and password
        [HttpGet("{search}/{name}")]
        public async Task<IActionResult> GetMedicineDetails(string name)
        {

            try
            {
                var result = await _mediRepo.GetMedicineByName(name);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion


        //Adding new Medicine
        #region Add Medicine
        [HttpPost]
        public async Task<IActionResult> AddMedicine([FromBody] Medicine medicine)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var mediId = await _mediRepo.AddMedicine(medicine);
                    if (mediId > 0)
                    {
                        return Ok(mediId);
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


        //Update Medicine
        #region UpdateMedicine
        [HttpPut]
        public async Task<IActionResult> UpdateMedicine([FromBody] Medicine medicine)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await _mediRepo.UpdateMedicine(medicine);
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


        //Delete Medicine details
        #region Delete Medicine            
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicineId(int? id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                result = await _mediRepo.DeleteMedicine(id);
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
