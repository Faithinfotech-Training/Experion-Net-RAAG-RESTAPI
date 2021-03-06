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
    public class DoctorRepository : IDoctorRepository
    {
        private readonly CMSDBContext _context;

        public DoctorRepository(CMSDBContext context)
        {
            _context = context;
        }


        public async Task<List<PrescribedMedicine>> GetAll()
        {
            if (_context != null)
            {                   //lambda expression
                return await _context.PrescribedMedicine.Include(p => p.Medicine).ToListAsync();
            }
            return null;
        }

        public async Task<int> AddPrescribedMedicine(PrescribedMedicine prescribedmedicine)
        {
            if (_context != null)
            {
                await _context.PrescribedMedicine.AddAsync(prescribedmedicine);
                await _context.SaveChangesAsync();
                return prescribedmedicine.Pmid;
            }
            return 0;
        }

        public async Task<int> AddPrescription(Prescription prescription)
        {

            if (_context != null)
            {
                await _context.Prescription.AddAsync(prescription);
                await _context.SaveChangesAsync();
                return prescription.PrescriptionId;
            }
            return 0;
        }

        

        public async Task<int> AddPrescriptionDetails(PrescriptionDetails prescriptiondetails)
        {
            if (_context != null)
            {
                await _context.PrescriptionDetails.AddAsync(prescriptiondetails);
                await _context.SaveChangesAsync();
                return prescriptiondetails.PdetailsId;
            }
            return 0;

        }

        public async Task<int> DeletePrescribedMedicine(int? id)
        {
            int result = 0;
            if (_context != null)
            {                                                                   //linq expression
                var premedicine = await _context.PrescribedMedicine.FirstOrDefaultAsync(pre => pre.Pmid == id);
                //check condition
                if (premedicine != null)
                {
                    //deleting the employee
                    _context.PrescribedMedicine.Remove(premedicine);

                    //commit the changes after deletion
                    result = await _context.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }

        public async Task<int> DeletePrescription(int? id)
        {
            int result = 0;
            if (_context != null)
            {                                                                   //linq expression
                var premed = await _context.Prescription.FirstOrDefaultAsync(pre => pre.PrescriptionId == id);
                //check condition
                if (premed != null)
                {
                    //deleting the employee
                    _context.Prescription.Remove(premed);

                    //commit the changes after deletion
                    result = await _context.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }

        public async Task<int> DeletePrescriptionDetails(int? id)
        {
            int result = 0;
            if (_context != null)
            {                                                                   //linq expression
                var prdetail = await _context.PrescriptionDetails.FirstOrDefaultAsync(prede => prede.PdetailsId== id);
                //check condition
                if (prdetail != null)
                {
                    //deleting the employee
                    _context.PrescriptionDetails.Remove(prdetail);

                    //commit the changes after deletion
                    result = await _context.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }

      

        public async Task UpdatePrescribedMedicine(PrescribedMedicine prescribedmedicine)
        {
            if(_context != null)
            {
                _context.Entry(prescribedmedicine).State = EntityState.Modified;
                _context.PrescribedMedicine.Update(prescribedmedicine);

                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdatePrescription(Prescription prescription)
        {
            if (_context != null)
            {
                _context.Entry(prescription).State = EntityState.Modified;
                _context.Prescription.Update(prescription);

                await _context.SaveChangesAsync();
            }

        }

        public async Task UpdatePrescriptionDetails(PrescriptionDetails prescriptiondetails)
        {
            if (_context != null)
            {
                _context.Entry(prescriptiondetails).State = EntityState.Modified;
                _context.PrescriptionDetails.Update(prescriptiondetails);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> AddPrescribedTest(PrescribedTest pretest)
        {
            if (_context != null)
            {
                await _context.PrescribedTest.AddAsync(pretest);
                await _context.SaveChangesAsync();
                return pretest.Ptid;
            }
            return 0;

        }

        public async Task<List<PrescribedTest>> Gettest()
        {
            if (_context != null)
            {
                return await _context.PrescribedTest.ToListAsync();
            }
            return null;
        }

        public async Task<List<DoctorViewModel>> GetAllAppointments(int id)
        {
            if (_context != null)
            {
                //LINQ
                //join post and category
                return await (from u in _context.Patient
                              from r in _context.Appoinment
                              from s in _context.Token
                              from h in _context.Doctor
                              from e in _context.Employee
                              where u.PatientId == r.PatientId && s.DoctorId == h.DoctorId && e.EmployeeId ==id
                              && r.AppointmentId == s.AppointmentId && e.EmployeeId == h.EmployeeId &&s.TokenDate == DateTime.Today
                              select new DoctorViewModel
                              {
                                  AppoinmentId = r.AppointmentId,
                                  FirstName = u.FirstName,
                                  LastName = u.LastName,
                                  TokenNo = s.TokenNo,
                                  TokenDate =s.TokenDate,
                                  DoctorName = e.FirstName    
                              }
                              ).ToListAsync();
            }
            return null;
        }

        public async Task UpdatePrescribedTest(PrescribedTest prescriptiontest)
        {
            if (_context != null)
            {
                _context.Entry(prescriptiontest).State = EntityState.Modified;
                _context.PrescribedTest.Update(prescriptiontest);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> DeletePrescribedTest(int? id)
        {
            int result = 0;
            if (_context != null)
            {                                                                   //linq expression
                var pret = await _context.PrescribedTest.FirstOrDefaultAsync(pre => pre.Ptid == id);
                //check condition
                if (pret != null)
                {
                    //deleting the employee
                    _context.PrescribedTest.Remove(pret);

                    //commit the changes after deletion
                    result = await _context.SaveChangesAsync();
                }
                return result;
            }
            return result;

        }

        public async Task<List<Dosage>> GetDosage()
        {
            if (_context != null)
            {
                return await _context.Dosage.ToListAsync();
            }
            return null;
        }

        public async Task<List<Test>> GetTests()
        {
            if (_context != null)
            {
                return await _context.Test.ToListAsync();
            }
            return null;
        }

        public  async Task<List<TestUnit>> GetUnit()
        {
            if (_context != null)
            {
                return await _context.TestUnit.ToListAsync();
            }
            return null;
        }

        public async Task<int> AddTestDetail(TestDetails testdetail)
        {
            if (_context != null)
            {
                await _context.TestDetails.AddAsync(testdetail);
                await _context.SaveChangesAsync();
                return testdetail.Tdid;
            }
            return 0;
        }

        public async Task<int> AddTestprescribe(TestPrescription testpre)
        {
            if (_context != null)
            {
                await _context.TestPrescription.AddAsync(testpre);
                await _context.SaveChangesAsync();
                return testpre.TprescriptionId;
            }
            return 0;
        }


        //public async Task<IEnumerable<Appoinment>> GetAllAppointmentOnDoctorID(int doctorId)
        //{
        //    IQueryable<App> query = _context.Users;
        //    if (!string.IsNullOrEmpty(contact))
        //    {
        //        query = query.Where(e => e.UserContact.Contains(contact));
        //    }
        //    return await query.ToListAsync();

        //}

        #region to view doctors by depid  --VIEWMODEL
        public async Task<List<DoctorViewModel>> GetDoctorsByDepId(int DepId)
        {
            return await
               (
                from s in _context.Doctor
                from e in _context.Employee
                where
                (
                    s.DepId == DepId
                    && s.EmployeeId == e.EmployeeId

                )
                select new DoctorViewModel
                {
 
                    DoctorId = s.DoctorId,
                    DepId = s.DepId,
                    DoctorName = e.FirstName
                }
                ).ToListAsync();
        }
        #endregion
        public async Task<int> AddNotes(DoctorNotes note)
        {
            if (_context != null)
            {
                await _context.DoctorNotes.AddAsync(note);
                await _context.SaveChangesAsync();
                return note.DnId;
            }
            return 0;
        }
       


    }
}
