using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS_Api_Raag.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMS_Api_Raag.Repository
{
    public class PatientRepository : IPatientRepository
    {
        //data fields
        private readonly CMSDBContext _context;

        //default constructor
        //constructor based dependency injection
        public PatientRepository(CMSDBContext context)
        {
            _context = context;
        }

        //Implement the interface

        //Method to get all patients
        #region Get All Patient
        public async Task<List<Patient>> GetAllPatients()
        {
            if (_context != null)
            {
                return await _context.Patient.ToListAsync();
            }
            return null;
        }

        #endregion

        //Method to add a new patient
        #region Add Patient
        public async Task<int> AddPatient(Patient patient)
        {
            if (_context != null)
            {
                await _context.Patient.AddAsync(patient);
                await _context.SaveChangesAsync(); 
                return patient.PatientId;
            }
            return 0;
        }
        #endregion

        //method to update a patient detail
        #region update an Patient
        public async Task UpdatePatient(Patient patient)
        {
            if (_context != null)
            {
                _context.Entry(patient).State = EntityState.Modified;
                _context.Patient.Update(patient);
                await _context.SaveChangesAsync();

            }
        }
        #endregion

        //method to get a patient by id
        #region get Patient by id
        public async Task<ActionResult<Patient>> GetPatientById(int? id)
        {
            if (_context != null)
            {
                var patient = await _context.Patient.FindAsync(id); 
                return patient;
            }
            return null;
        }
        #endregion

        //method to delete a patient
        #region delete a Patient
        public async Task<int> DeletePatient(int? id)
        {
            int result = 0;
            if (_context != null)
            {                                           
                var patient = await _context.Patient.FirstOrDefaultAsync(patient => patient.PatientId == id);
                //check condition
                if (patient != null)
                {
                    //delete
                    _context.Patient.Remove(patient);

                    //commit
                    result = await _context.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }
        #endregion

        #region get patient by contact
        public async Task<IEnumerable<Patient>> GetPatientByContact(string contact)
        {
            IQueryable<Patient> query = _context.Patient;
            if (!string.IsNullOrEmpty(contact))
            {
                query = query.Where(e => e.PhoneNumber.Contains(contact));
            }
            return await query.ToListAsync();
        }
        #endregion


        public async Task<List<Patient>> getpatient(int patientId)
        {
            return await (from p in _context.Patient
                          where p.PatientId == patientId
                          select new Patient
                          {

                              PatientId = p.PatientId,
                              FirstName = p.FirstName,
                              LastName = p.LastName,
                              Gender = p.Gender,
                              BloodGroup = p.BloodGroup,
                              Dob = p.Dob,
                              Address = p.Address,
                              EmailAddress = p.EmailAddress,
                              PhoneNumber = p.PhoneNumber,
                              Pincode = p.Pincode
                          }
                ).ToListAsync();
        }
    }
}