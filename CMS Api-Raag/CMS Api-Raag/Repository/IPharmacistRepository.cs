using CMS_Api_Raag.Models;
using CMS_Api_Raag.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_Api_Raag.Repository
{
    public interface IPharmacistRepository
    {
        // get prescription list view model

        Task<List<PrescriptionListViewModel>> viewPrescriptions();

        // get all medicine details in a prescription using prescription id
        Task<List<PrescriptionmedicinesViewModel>> viewPrescriptionMedicines(int PresId);


        //get all bill
        Task<List<MedicineBill>> GetAllMedicineBills();

        // get bill by id
        Task<ActionResult<MedicineBill>> GetMedicineBillById(int? Mid);

        // add to bill
        Task<int> AddToMedicineBill(MedicineBill medcinebill);
    }
    
}
