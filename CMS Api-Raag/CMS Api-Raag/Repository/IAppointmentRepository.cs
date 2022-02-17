using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS_Api_Raag.Models;
using CMS_Api_Raag.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CMS_Api_Raag.Repository
{
    public interface IAppointmentRepository
    {
        //Get all Appointments       
        Task<List<Appoinment>> GetAllAppoinments();

        //Add an Appointment
        Task<int> AddAppoinment(Appoinment appoinment);

        //Update an Appointment
        Task UpdateAppoinment(Appoinment appoinment);

        //Delete a Appointment
        Task<int> DeleteAppoinment(int? id);

        //get an Appointment by id
        Task<ActionResult<Appoinment>> GetAppoinmentById(int? id);

        // get all appointments --view Model
        Task<List<AppointmentViewModel>> GetAllAppointments();

        //to insert into all 3 tables
        Task<int> ScheduleAppoinment(AppointmentViewModel appoinment);


    }
}
