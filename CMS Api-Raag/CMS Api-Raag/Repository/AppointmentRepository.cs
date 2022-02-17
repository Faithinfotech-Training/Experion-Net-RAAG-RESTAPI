using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS_Api_Raag.Models;
using CMS_Api_Raag.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMS_Api_Raag.Repository
{
    public class AppointmentRepository :IAppointmentRepository
    {
        //data fields
        private readonly CMSDBContext _context;

        //default constructor
        //constructor based dependency injection
        public AppointmentRepository(CMSDBContext context)
        {
            _context = context;
        }

        //Implement the interface

        //Method to get all Appoinment
        #region Get All Appoinment
        public async Task<List<Appoinment>> GetAllAppoinments()
        {
            if (_context != null)
            {
                return await _context.Appoinment.ToListAsync();
            }
            return null;
        }

        #endregion

        //Method to add a new Appoinment
        #region Add Appoinment
        public async Task<int> AddAppoinment(Appoinment appoinment)
        {
            if (_context != null)
            {
                await _context.Appoinment.AddAsync(appoinment);
                await _context.SaveChangesAsync();
                return appoinment.AppointmentId;
            }
            return 0;
        }
        #endregion

        //method to update a Appoinment
        #region update an Appoinment
        public async Task UpdateAppoinment(Appoinment appoinment)
        {
            if (_context != null)
            {
                _context.Entry(appoinment).State = EntityState.Modified;
                _context.Appoinment.Update(appoinment);
                await _context.SaveChangesAsync();

            }
        }
        #endregion

        //method to get a Appoinment by id
        #region get Appoinment by id
        public async Task<ActionResult<Appoinment>> GetAppoinmentById(int? id)
        {
            if (_context != null)
            {
                var appoinment = await _context.Appoinment.FindAsync(id);
                return appoinment;
            }
            return null;
        }
        #endregion

        //method to delete a Appoinment
        #region delete a Appoinment
        public async Task<int> DeleteAppoinment(int? id)
        {
            int result = 0;
            if (_context != null)
            {
                var appoinment = await _context.Appoinment.FirstOrDefaultAsync(appoinment => appoinment.AppointmentId == id);
                //check condition
                if (appoinment != null)
                {
                    //delete
                    _context.Appoinment.Remove(appoinment);

                    //commit
                    result = await _context.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }
        #endregion


        //get all appointments --view model

        public async Task<List<AppointmentViewModel>> GetAllAppointments()
        {
            if (_context != null)
            {
                //LINQ
                return await (from u in _context.Patient
                              from r in _context.Appoinment
                              from s in _context.Token
                              from h in _context.Doctor
                              from e in _context.Employee
                              where u.PatientId == r.PatientId && s.DoctorId == h.DoctorId
                              && r.AppointmentId == s.AppointmentId && e.EmployeeId == h.EmployeeId
                              select new AppointmentViewModel
                              {
                                  AppoinmentId = r.AppointmentId,
                                  FirstName = u.FirstName,
                                  LastName = u.LastName,
                                  TokenNo = s.TokenNo,
                                  TokenDate = s.TokenDate,
                                  DoctorName = e.FirstName
                              }
                              ).ToListAsync();
            }
            return null;
        }


        public async Task<int> ScheduleAppoinment(AppointmentViewModel appoinment)
        {
            Appoinment appoinment1 = new Appoinment();
            appoinment1.AppointmentId = appoinment.AppoinmentId;
            appoinment1.PatientId = appoinment.PatientId;
            appoinment1.EmployeeId = appoinment.EmployeeId;

            await _context.Appoinment.AddAsync(appoinment1);
            await _context.SaveChangesAsync();
            return appoinment1.AppointmentId;
        }
    }
}
