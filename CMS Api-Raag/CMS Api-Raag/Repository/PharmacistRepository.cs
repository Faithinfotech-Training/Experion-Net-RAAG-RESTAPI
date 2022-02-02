using CMS_Api_Raag.Models;
using CMS_Api_Raag.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_Api_Raag.Repository
{
    public class PharmacistRepository : IPharmacistRepository
    {

        // Data fields
        private readonly CMSDBContext _context;

        // default constructor
        public PharmacistRepository(CMSDBContext context)
        {
            _context = context;
        }

        #region prescription lists
        public async Task<List<PrescriptionListViewModel>> viewPrescriptions()
        {

            return await (
                from pres in _context.Prescription
                from A in _context.Appoinment
                from P in _context.Patient
                from T in _context.Token
                from D in _context.Doctor
                from E in _context.Employee
                where (
                    pres.AppointmentId == A.AppointmentId &&
                    A.AppointmentId == T.AppointmentId &&
                    A.PatientId == P.PatientId &&
                    pres.DoctorId == D.DoctorId &&
                    D.EmployeeId == E.EmployeeId)
                select new PrescriptionListViewModel
                {
                    AppointmentId = A.AppointmentId,
                    PatientFname = P.FirstName,
                    PatientLname = P.LastName,
                    DocttorFname = E.FirstName,
                    DocttorLname = E.LastName,
                    PrescriptionId = pres.PrescriptionId,
                    TokenDate = T.TokenDate
                }).ToListAsync();
            //throw new NotImplementedException();
        }
        #endregion

        #region prescription medicines
        public async Task<List<PrescriptionmedicinesViewModel>> viewPrescriptionMedicines(int PresId)
        {
            return await(
                
            from P in _context.Prescription
            from PD in _context.PrescriptionDetails
            from PM in _context.PrescribedMedicine
            from M in _context.Medicine
            from D in _context.Dosage
            where(
                 P.PrescriptionId == PresId &&
                 PD.PrescriptionId == P.PrescriptionId &&
                 PD.Pmid == PM.Pmid &&
                 PM.MedicineId == M.MedicineId &&
                 PM.DosageId == D.DosageId
                )
            select new PrescriptionmedicinesViewModel
            {
                 Medicinename = M.MedicineName,
                 Dosage = D.Dosage1,
                 Quantity = (int)PM.Quantity,
                 PriceperUnit = M.UnitPrice
            }
            ).ToListAsync();
            //throw new NotImplementedException();
        }


        #endregion

        /*
        #region Get all medicine bills
        public async Task<List<MedicineBill>> GetAllMedicineBills()
        {
            if (_context != null)
            {
                return await _context.MedicineBill.Include(p => p.Prescription).Include(a => a.Appointment).ToListAsync();
            }
            return null;
            //throw new NotImplementedException();
        }
        #endregion

        #region Add medicine bill

        public async Task<int> AddToMedicineBill(MedicineBill medcinebill)
        {
            if (_context != null)
            {
                await _context.MedicineBill.AddAsync(medcinebill);
                await _context.SaveChangesAsync(); // commit transaction
                return medcinebill.MbillId;
            }
            return 0;
            //throw new NotImplementedException();
        }
        #endregion
        public async Task<ActionResult<MedicineBill>> GetMedicineBillById(int? Mid)
        {
            if (_context != null)
            {
                var bill = await _context.MedicineBill.FindAsync(Mid);
                return bill;
            }
            return null;
        }*/
    }
}
