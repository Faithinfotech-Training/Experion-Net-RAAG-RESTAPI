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
    public class DoctorsController : ControllerBase
    {
        public readonly IDoctorRepository _docrepo;

        public DoctorsController(IDoctorRepository doc)
        {
            _docrepo = doc;
        }



        [HttpGet]
        [Route("GetAllMedicine")]
        public async Task<ActionResult<IEnumerable<PrescribedMedicine>>> GetAllMedicine()
        {
            try
            {
                var med = await _docrepo.GetAll();
                if (med == null)
                {
                    return NotFound();
                }
                return Ok(med);
            }
            catch
            {
                return BadRequest();
            }
        }



        #region Adding prescription         

        [HttpPost]
        [Route("AddPrescription")]
        public async Task<IActionResult> AddPrescription([FromBody] Prescription prescription)
        {
            //check the validation of body
            if (ModelState.IsValid)

            {
                try
                {
                    var Id = await _docrepo.AddPrescription(prescription);
                    if (Id > 0)
                    {
                        return Ok(Id);

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

        [HttpPost]
        [Route("AddPrescriptionDetails")]
        public async Task<IActionResult> AddPrescriptionDetails([FromBody] PrescriptionDetails prescriptiondetails)
        {
            //check the validation of body
            if (ModelState.IsValid)

            {
                try
                {
                    var Id = await _docrepo.AddPrescriptionDetails(prescriptiondetails);
                    if (Id > 0)
                    {
                        return Ok(Id);

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

        [HttpPost]
        [Route("AddPrescribedMedicine")]
        public async Task<IActionResult> AddPrescribedMedicine([FromBody] PrescribedMedicine prescribedmedicine)
        {
            //check the validation of body
            if (ModelState.IsValid)

            {
                try
                {
                    var Id = await _docrepo.AddPrescribedMedicine(prescribedmedicine);
                    if (Id > 0)
                    {
                        return Ok(Id);

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


        #region For Updating Patient detail

        [HttpPut]
        [Route("UpdatePrescription")]
        public async Task<IActionResult> UpdatePrescription([FromBody] Prescription prescription)
        {
            //check the validation of body
            if (ModelState.IsValid)

            {
                try
                {
                    await _docrepo.UpdatePrescription(prescription);

                    return Ok();

                }
                catch (Exception)
                {
                    return BadRequest();
                }


            }
            return BadRequest();
        }

        [HttpPut]
        [Route("UpdatePrescriptionDetails")]
        public async Task<IActionResult> UpdatePrescriptionDetails([FromBody] PrescriptionDetails prescriptionDetails)
        {
            //check the validation of body
            if (ModelState.IsValid)

            {
                try
                {
                    await _docrepo.UpdatePrescriptionDetails(prescriptionDetails);

                    return Ok();

                }
                catch (Exception)
                {
                    return BadRequest();
                }


            }
            return BadRequest();
        }



        [HttpPut]
        [Route("UpdatePrescribedMedicine")]
        public async Task<IActionResult> UpdatePrescribedMedicine([FromBody] PrescribedMedicine prescribedmedicine)
        {
            //check the validation of body
            if (ModelState.IsValid)

            {
                try
                {
                    await _docrepo.UpdatePrescribedMedicine(prescribedmedicine);

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




        #region delete 
      
        [HttpDelete("prescription/{id}")]
        public async Task<IActionResult> DeletePrescription(int? id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                result = await _docrepo.DeletePrescription(id);
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


        [HttpDelete("prescribedmedicine/{id}")]
        public async Task<IActionResult> DeletePrescriptionDetails(int? id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                result = await _docrepo.DeletePrescriptionDetails(id);
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

        [HttpDelete("prescriptiondetail/{id}")]
        public async Task<IActionResult> DeletePrescribedMedicine(int? id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                result = await _docrepo.DeletePrescribedMedicine(id);
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


        #region Prescription test crud operation

        [HttpPost]
        [Route("AddPrescribedTest")]
        public async Task<IActionResult> AddPrescribedTest([FromBody] PrescribedTest prescribedtest)
        {
            //check the validation of body
            if (ModelState.IsValid)

            {
                try
                {
                    var Id = await _docrepo.AddPrescribedTest(prescribedtest);
                    if (Id > 0)
                    {
                        return Ok(Id);

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

        [HttpGet]
        [Route("Gettest")]
        public async Task<ActionResult<IEnumerable<PrescribedTest>>> Gettest()
        {
            return await  _docrepo.Gettest();
        }

        [HttpGet]
        [Route("Getdosage")]
        public async Task<ActionResult<IEnumerable<Dosage>>> Getdosage()
        {
            return await  _docrepo.GetDosage();
        }

        [HttpGet]
        [Route("Gettestname")]
        public async Task<ActionResult<IEnumerable<Test>>> Gettestname()
        {
            return await _docrepo.GetTests();
        }


        [HttpGet]
        [Route("Getunit")]
        public async Task<ActionResult<IEnumerable<TestUnit>>> Getunit()
        {
            return await _docrepo.GetUnit();
        }



        [HttpDelete("prescribedtest/{id}")]
        public async Task<IActionResult> DeletePrescribedTest(int? id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                result = await _docrepo.DeletePrescribedTest(id);
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

        [HttpPut]
        [Route("UpdatePrescribedtest")]
        public async Task<IActionResult> UpdatePrescribedtest([FromBody] PrescribedTest pretest)
        {
            //check the validation of body
            if (ModelState.IsValid)

            {
                try
                {
                    await _docrepo.UpdatePrescribedTest(pretest);

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


        [HttpGet]
        [Route("GetAllAppoinment")]
        public async Task<IActionResult> GetAllAppoinment()
        {
            try
            {
                var users = await _docrepo.GetAllAppointments();
                if (users == null)
                {
                    return NotFound();
                }
                return Ok(users);
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
