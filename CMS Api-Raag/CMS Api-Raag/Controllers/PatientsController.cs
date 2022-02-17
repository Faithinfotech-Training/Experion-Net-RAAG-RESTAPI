using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS_Api_Raag.Models;
using Microsoft.AspNetCore.Authorization;
using CMS_Api_Raag.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS_Api_Raag.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository; 

        //constructor injection
        public PatientsController(IPatientRepository patientRepository) 
        {
            _patientRepository = patientRepository;
        }

        #region Get All Patients
        //EndPoint :- https://localhost:44343/api/patients
        [HttpGet]
        //  [Authorize]
        //  [Authorize(AuthenticationSchemes ="Bearer")] 
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatientsAll()
        {
            return await _patientRepository.GetAllPatients();
        }

        #endregion

        #region Add Patient
        //EndPoint :- https://localhost:44343/api/patients
        [HttpPost]
        public async Task<IActionResult> AddPatient([FromBody] Patient patient)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var patientId = await _patientRepository.AddPatient(patient);
                    if (patientId > 0)
                    {
                        return Ok(patientId);
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

        #region Update an Patient
        //EndPoint :- https://localhost:44343/api/patients
        [HttpPut]
        public async Task<IActionResult> UpdatePatient([FromBody] Patient patient)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await _patientRepository.UpdatePatient(patient);
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

        #region find an Patient by id

        //Endpoint:https://localhost:44360/api/Patient/3
        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetPatientById(int? id)
        {
            try
            {
                var patient = await _patientRepository.GetPatientById(id);
                if (patient == null)
                {
                    return NotFound();
                }
                return patient;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region delete an Patient
        //Endpoint:https://localhost:44360/api/Patient/3
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatientById(int? id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                result = await _patientRepository.DeletePatient(id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();  //return ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region find a Patient by contact

        //Endpoint : - https://localhost:44336/api/patients/search/9747240955
        [HttpGet("{search}/{contact}")]
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatientByContact(string contact)
        {
            try
            {
                var result = await _patientRepository.GetPatientByContact(contact);
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


        #region Prescription medicine list
        [HttpGet("getpatient")]
        public async Task<List<Patient>> getAllTestPrescriptionTests(int patientId)
        {
            return await _patientRepository.getpatient(patientId);
        }

        #endregion
    }
}
