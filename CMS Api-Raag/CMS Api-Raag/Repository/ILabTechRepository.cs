using CMS_Api_Raag.Models;
using CMS_Api_Raag.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_Api_Raag.Repository
{
    public interface ILabTechRepository
    {
        // get labtest lists view model

        Task<List<LabTestListViewmodel>> viewTestPrescriptions();

        // get all test details in a Test using Test id
        Task<List<LabTestDetailsViewModel>> viewTestPrescriptionTests(int testId);
        /*
        //get all test bill
        Task<List<TestBill>> GetAllTestBills();

        // get test bill by id
        Task<ActionResult<TestBill>> GetTestBillById(int? id);

        // add to testbill
        Task<int> AddToTestBill(TestBill testbill);
        */
    }
}
