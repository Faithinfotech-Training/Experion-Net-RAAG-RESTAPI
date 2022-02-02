using CMS_Api_Raag.Models;
using CMS_Api_Raag.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_Api_Raag.Repository
{
    public class LabTechRepository : ILabTechRepository
    {
        // Data fields
        private readonly CMSDBContext _context;

        // default constructor
        public LabTechRepository(CMSDBContext context)
        {
            _context = context;
        }
        public async Task<List<LabTestListViewmodel>> viewTestPrescriptions()
        {

            return await(
               from testPres in _context.TestPrescription
               from A in _context.Appoinment
               from P in _context.Patient
               from T in _context.Token
               from D in _context.Doctor
               from E in _context.Employee
               where (
                   testPres.AppointmentId == A.AppointmentId &&
                   A.AppointmentId == T.AppointmentId &&
                   A.PatientId == P.PatientId &&
                   testPres.DoctorId == D.DoctorId &&
                   D.EmployeeId == E.EmployeeId)
               select new LabTestListViewmodel
               {
                   AppointmentId = A.AppointmentId,
                   PatientFname = P.FirstName,
                   PatientLname = P.LastName,
                   DocttorFname = E.FirstName,
                   DocttorLname = E.LastName,
                   TestprescriptionId = testPres.TprescriptionId,
                   TokenDate = T.TokenDate
               }).ToListAsync();
            //throw new NotImplementedException();
        }

        public async Task<List<LabTestDetailsViewModel>> viewTestPrescriptionTests(int testId)
        {
            return await(

            from TP in _context.TestPrescription
            from TD in _context.TestDetails
            from PT in _context.PrescribedTest
            from T in _context.Test
            from U in _context.TestUnit
            where (
                    TP.TprescriptionId == testId &&
                    TD.TprescriptionId == TP.TprescriptionId &&
                    TD.Ptid == PT.Ptid &&
                    PT.TestId == T.TestId &&
                    PT.UnitId == U.UnitId
                )
            select new LabTestDetailsViewModel
            {
                Testname = T.TestName,
                Testvalue = PT.Result,
                Normalrange = PT.NormalValue,
                Unit = U.Unit
            }
            ).ToListAsync();
        }
    }
}
