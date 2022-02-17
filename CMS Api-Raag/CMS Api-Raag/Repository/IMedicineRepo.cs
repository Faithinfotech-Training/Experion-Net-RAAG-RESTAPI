using CMS_Api_Raag.Models;
using CMS_Api_Raag.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_Api_Raag.Repository
{
    public interface IMedicineRepo
    {
        //View Medicine details
        Task<List<Medicine>> GetMedicines();


        //view Medicine details ----ViewModel
        Task<List<MedicineViewModel>> GetAllMedicines();

        //view Medicine by medicine name    --viewModel
        Task<MedicineViewModel> GetMedicineByName(string name);

        //Add Medicine details
        Task<int> AddMedicine(Medicine medicine);


        //Update Medicine Details
        Task UpdateMedicine(Medicine medicine);


        //Deleting an Medicine details
        Task<int> DeleteMedicine(int? id);

        //view medicine details by id
        Task<ActionResult<Medicine>> GetMedicineById(int? id);




    }
}
