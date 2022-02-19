using CMS_Api_Raag.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_Api_Raag.Repository
{
    public interface IlabTestRepository
    {
        //get all test bill
        Task<List<TestBill>> GetAllTestBills();

        // get test bill by id
        Task<ActionResult<TestBill>> GetTestBillById(int? id);

        // get test bill by id
        Task<List<TestBill>> GetTestBillByPresId(int? PresId);

        // add to testbill
        Task<int> AddToTestBill(TestBill testbill);

        //For adding test resylt
        Task<int> AddTestResult(PrescribedTest testresult);

        //Updating test results
        Task UpdateTestresult(PrescribedTest testresult);
    }
}
