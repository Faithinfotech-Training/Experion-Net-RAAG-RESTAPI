using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS_Api_Raag.Models;
using Microsoft.AspNetCore.Mvc;

namespace CMS_Api_Raag.Repository
{
    public interface IPatientRepository
    {
        //Get all patients       
        Task<List<Patient>> GetAllPatients();

        //Add an Patient
        Task<int> AddPatient(Patient patient);

        //Update an Patient 
        Task UpdatePatient(Patient patient);

        //Delete a Patient
        Task<int> DeletePatient(int? id);

        //get an Patient by id
        Task<ActionResult<Patient>> GetPatientById(int? id);

        //Find patient by phonenumber
        Task<IEnumerable<Patient>> GetPatientByContact(string contact);

        Task<List<Patient>> getpatient (int patientId);


        Task<List<Patient>> getpatientbycontact(string contact);
    }
}
