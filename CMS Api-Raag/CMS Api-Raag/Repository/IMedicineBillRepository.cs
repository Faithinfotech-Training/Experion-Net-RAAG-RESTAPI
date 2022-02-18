using CMS_Api_Raag.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_Api_Raag.Repository
{
    public interface IMedicineBillRepository
    {
        //get all bill
        Task<List<MedicineBill>> GetAllMedicineBills();

        // get bill by id
        Task<ActionResult<MedicineBill>> GetMedicineBillById(int? id);

        // get medicine bill by prescription id
        Task<List<MedicineBill>> GetMedicineBillByPresId(int? PresId);

        // add to bill
        Task<int> AddToMedicineBill(MedicineBill medcinebill);
    }
}
