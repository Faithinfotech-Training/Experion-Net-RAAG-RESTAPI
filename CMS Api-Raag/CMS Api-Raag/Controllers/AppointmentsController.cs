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
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentRepository _appointmentRepository;

        //constructor injection
        public AppointmentsController(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        #region Get All Appoinment
        //EndPoint :-
        [HttpGet]
        //  [Authorize]
        //  [Authorize(AuthenticationSchemes ="Bearer")] 
        public async Task<ActionResult<IEnumerable<Appoinment>>> AppoinmentsAll()
        {
            return await _appointmentRepository.GetAllAppoinments();
        }

        #endregion
        #region Add Appoinment
        //EndPoint :- 
        [HttpPost]
        public async Task<IActionResult> AddAppoinment([FromBody] Appoinment appoinment)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var appoinmentId = await _appointmentRepository.AddAppoinment(appoinment);
                    if (appoinmentId > 0)
                    {
                        return Ok(appoinment);
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

        #region Update an Appoinment
        //EndPoint :- 
        [HttpPut]
        public async Task<IActionResult> UpdateAppoinment([FromBody] Appoinment appoinment)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await _appointmentRepository.UpdateAppoinment(appoinment);
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

        #region find an Appoinment by id

        //Endpoint:
        [HttpGet("{id}")]
        public async Task<ActionResult<Appoinment>> GetAppoinmentById(int? id)
        {
            try
            {
                var appoinment = await _appointmentRepository.GetAppoinmentById(id);
                if (appoinment == null)
                {
                    return NotFound();
                }
                return appoinment;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region delete an Appoinment
        //Endpoint:
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppoinmentById(int? id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                result = await _appointmentRepository.DeleteAppoinment(id);
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


        //get all appointments -- view mode
        [HttpGet]
        [Route("GetAllAppoinment")]
        public async Task<IActionResult> GetAllAppoinment()
        {
            try
            {
                var users = await _appointmentRepository.GetAllAppointments();
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

        //POST method to insert into multiple tables
        [HttpPost]
        [Route("scheduleappoinment")]
        public async Task<IActionResult> ScheduleAppoinment([FromBody] AppointmentViewModel appoinment)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var appoinmentId = await _appointmentRepository.ScheduleAppoinment(appoinment);
                    if(appoinmentId >0)
                    {
                        return Ok(appoinmentId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch(Exception)
                {

                    return BadRequest();

                }
            }
            return BadRequest();
        }
    }
}
