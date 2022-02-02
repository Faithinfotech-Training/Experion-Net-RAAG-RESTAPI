using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS_Api_Raag.Models;
using CMS_Api_Raag.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CMS_Api_Raag.Repository
{
    public interface IConsultationBillRepository
    {
        //Get all consultation bills      
        Task<List<ConsultationBillDetails>> GetAllConsultationBill();

        //Add a ConsultationBill
        Task<int> AddConsultationBill(ConsultationBillDetails patient);

        //Update a ConsultationBill
        Task UpdateConsultationBill(ConsultationBillDetails patient);

        //Delete a ConsultationBill
        Task<int> DeleteConsultationBill(int? id);

        //get a Bill by id  --normal search
        Task<ActionResult<ConsultationBillDetails>> GetConsultationBillById(int? id);

        //get  consultation bill ---view model
        Task<List<ConsultationBillViewModel>> GetConsultationBill();

        //get  consultation bill by id ---view model  
        Task<List<ConsultationBillViewModel>> GetConsultationBillsByAppointmentId(int AppointmentId);
    }
}
