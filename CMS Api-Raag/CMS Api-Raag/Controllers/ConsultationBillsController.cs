using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS_Api_Raag.Models;
using CMS_Api_Raag.Repository;
using CMS_Api_Raag.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS_Api_Raag.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultationBillsController : ControllerBase
    {
        private readonly IConsultationBillRepository _consultationBillRepository;

        //constructor injection
        public ConsultationBillsController(IConsultationBillRepository consultationBillRepository)
        {
            _consultationBillRepository = consultationBillRepository;
        }

        #region Get All ConsultationBillDetails
        //EndPoint :-
        [HttpGet]
        //  [Authorize]
        //  [Authorize(AuthenticationSchemes ="Bearer")] 
        public async Task<ActionResult<IEnumerable<ConsultationBillDetails>>> GetConsultationBillsAll()
        {
            return await _consultationBillRepository.GetAllConsultationBill();
        }

        #endregion

        #region Add ConsultationBillDetails
        //EndPoint :- 
        [HttpPost]
        public async Task<IActionResult> AddPatient([FromBody] ConsultationBillDetails consultationBillDetails)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var consultationBillId = await _consultationBillRepository.AddConsultationBill(consultationBillDetails);
                    if (consultationBillId > 0)
                    {
                        return Ok(consultationBillId);
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

        #region Update an ConsultationBillDetails
        //EndPoint :- 
        [HttpPut]
        public async Task<IActionResult> UpdateConsultationBill([FromBody] ConsultationBillDetails consultationBillDetails)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await _consultationBillRepository.UpdateConsultationBill(consultationBillDetails);
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

        #region find an ConsultationBillDetails by id

        //Endpoint:
        [HttpGet("{id}")]
        public async Task<ActionResult<ConsultationBillDetails>> GetConsultationBillById(int? id)
        {
            try
            {
                var consultationBillDetails = await _consultationBillRepository.GetConsultationBillById(id);
                if (consultationBillDetails == null)
                {
                    return NotFound();
                }
                return consultationBillDetails; 
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region delete an ConsultationBillDetails
        //Endpoint:
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsultationBillById(int? id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                result = await _consultationBillRepository.DeleteConsultationBill(id);
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


        #region Get All users  --view model
        //Endpoint :- 
        [HttpGet]
        [Route("Bill")]
        public async Task<IActionResult> GetConsultationBill()
        {
            try
            {
                var consultationbill = await _consultationBillRepository.GetConsultationBill();
                if (consultationbill == null)
                {
                    return NotFound();
                }
                return Ok(consultationbill);
            }
            catch
            {
                return BadRequest();
            }
        }
        #endregion

        #region generate an ConsultationBill by id --view model

        //Endpoint:
        [HttpGet("Bill/{AppointmentId}")]
        public async Task<ActionResult<IEnumerable<ConsultationBillViewModel>>> GetConsultationBillsById(int AppointmentId)
        {
            try
            {
                return await _consultationBillRepository.GetConsultationBillsByAppointmentId(AppointmentId);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion
    }
}
