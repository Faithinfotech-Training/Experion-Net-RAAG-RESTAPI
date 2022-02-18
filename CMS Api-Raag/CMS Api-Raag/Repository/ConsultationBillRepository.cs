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
    public class ConsultationBillRepository : IConsultationBillRepository
    {
        //data fields
        private readonly CMSDBContext _context;

        //default constructor
        //constructor based dependency injection
        public ConsultationBillRepository(CMSDBContext context)
        {
            _context = context;
        }

        //Implement the interface

        //Method to get all ConsultationBillDetails
        #region Get All ConsultationBill
        public async Task<List<ConsultationBillDetails>> GetAllConsultationBill()
        {
            if (_context != null)
            {
                return await _context.ConsultationBillDetails.ToListAsync();
            }
            return null;
        }

        #endregion

        //Method to add a new ConsultationBill
        #region Add Patient
        public async Task<int> AddConsultationBill(ConsultationBillDetails consultationBillDetails)
        {
            if (_context != null)
            {
                await _context.ConsultationBillDetails.AddAsync(consultationBillDetails);
                await _context.SaveChangesAsync();
                return consultationBillDetails.CbillId;
            }
            return 0;
        }
        #endregion

        //method to update a ConsultationBill
        #region update an ConsultationBill
        public async Task UpdateConsultationBill(ConsultationBillDetails consultationBillDetails)
        {
            if (_context != null)
            {
                _context.Entry(consultationBillDetails).State = EntityState.Modified;
                _context.ConsultationBillDetails.Update(consultationBillDetails);
                await _context.SaveChangesAsync();

            }
        }
        #endregion

        //method to get a ConsultationBill by id
        #region get ConsultationBill by id
        public async Task<ActionResult<ConsultationBillDetails>> GetConsultationBillById(int? id)
        {
            if (_context != null)
            {
                var consultationBillDetails = await _context.ConsultationBillDetails.FindAsync(id);
                return consultationBillDetails;
            }
            return null;
        }
        #endregion

        //method to delete a ConsultationBill
        #region delete a ConsultationBillDetails
        public async Task<int> DeleteConsultationBill(int? id)
        {
            int result = 0;
            if (_context != null)
            {
                var consultationBillDetails = await _context.ConsultationBillDetails.FirstOrDefaultAsync(consultationBillDetails => consultationBillDetails.CbillId == id);
                //check condition
                if (consultationBillDetails != null)
                {
                    //delete
                    _context.ConsultationBillDetails.Remove(consultationBillDetails);

                    //commit
                    result = await _context.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }
        #endregion

        #region to view consultation bill 
        public async Task<List<ConsultationBillViewModel>> GetConsultationBill()
        {
            if (_context != null)
            {
                //LINQ
                return await (from d in _context.Token
                              from u in _context.Appoinment
                              from r in _context.ConsultationBillDetails
                              where u.AppointmentId == r.AppointmentId && d.AppointmentId == u.AppointmentId
                              select new ConsultationBillViewModel
                              {
                                  CbillId = r.CbillId,
                                  AppointmentId = u.AppointmentId,
                                  FirstName = u.Patient.FirstName,
                                  DoctorId = d.Doctor.DoctorId,
                                  ConsultationFee = r.ConsultationFee,
                                  UpdatedDate = r.UpdatedDate
                              }
                              ).ToListAsync();
            }
            return null;
        }
        #endregion

        #region to view consultation bill by Appointmentid  --VIEWMODEL
        public async Task<List<ConsultationBillViewModel>> GetConsultationBillsByAppointmentId(int AppointmentId)
        {
            return await
               (from d in _context.Token
                from u in _context.Appoinment
                from r in _context.ConsultationBillDetails
                from s in _context.Doctor
                from e in _context.Employee
                where
                (
                    u.AppointmentId == AppointmentId
                    && u.AppointmentId == r.AppointmentId
                    && d.AppointmentId == u.AppointmentId
                    && r.AppointmentId == d.AppointmentId
                    && s.DoctorId == d.DoctorId
                    && s.EmployeeId == e.EmployeeId
                )
                select new ConsultationBillViewModel
                {
                    CbillId = r.CbillId,
                    AppointmentId = u.AppointmentId,
                    FirstName = u.Patient.FirstName,
                    DoctorId = d.Doctor.DoctorId,
                    ConsultationFee = r.ConsultationFee,
                    UpdatedDate = r.UpdatedDate,
                    TokenNo = d.TokenNo,
                    DoctorName = e.FirstName
                }
                ).ToListAsync();
        }
        #endregion
    }
}
