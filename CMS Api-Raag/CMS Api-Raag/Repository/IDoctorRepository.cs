﻿using CMS_Api_Raag.Models;
using CMS_Api_Raag.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_Api_Raag.Repository
{
  public  interface IDoctorRepository
    {


        // Task<IEnumerable<Appoinment>> GetAllAppointmentOnDoctorID(int doctorId);
        Task<List<PrescribedMedicine>> GetAll();

        Task<int> AddPrescription(Prescription prescription);
        Task<int> AddPrescriptionDetails(PrescriptionDetails prescriptiondetails);
        Task<int> AddPrescribedMedicine(PrescribedMedicine prescribedmedicine);

        // Task<List<Role>> GetRole();

        Task<int> DeletePrescription(int? id);
        Task<int> DeletePrescriptionDetails(int? id);
        Task<int> DeletePrescribedMedicine(int? id);

        //Task<List<Role>> GetRole();
        Task UpdatePrescription(Prescription prescription);

        Task UpdatePrescriptionDetails(PrescriptionDetails prescriptiondetails);

        Task UpdatePrescribedMedicine(PrescribedMedicine prescribedmedicine);


        Task<int> AddPrescribedTest(PrescribedTest pretest);

        Task UpdatePrescribedTest(PrescribedTest pretest);

        Task<int> DeletePrescribedTest(int? id);

        Task<List<PrescribedTest>> Gettest();

        Task<List<DoctorViewModel>> GetAllAppointments();



        //Task<List<PostViewModel>> GetAllPosts();

        //Task<PostViewModel> GetPost(int? postId);
    }
}
