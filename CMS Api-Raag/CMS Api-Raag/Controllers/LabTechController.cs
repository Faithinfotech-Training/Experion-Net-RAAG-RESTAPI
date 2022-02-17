using CMS_Api_Raag.Models;
using CMS_Api_Raag.Repository;
using CMS_Api_Raag.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_Api_Raag.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabTechController : ControllerBase
    {
        // data fields
        public readonly ILabTechRepository _ilabtechrepository;

        // default constructor
        public LabTechController(ILabTechRepository ilabtechrepository)
        {
            _ilabtechrepository = ilabtechrepository;
        }

        #region Testprescription list
        [HttpGet("testPrescriptionLists")]
        //https://localhost:44343/api/LabTech/testPrescriptionLists
        public async Task<IActionResult> getAllTestPrescriptions()
        {
            try
            {
                var viewData = await _ilabtechrepository.viewTestPrescriptions();
                if (viewData == null)
                {
                    return NotFound();
                }
                return Ok(viewData);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region Prescription medicine list
        [HttpGet("testPrescription-tests")]
        //https://localhost:44343/api/LabTech/testPrescription-tests?testId=2
        public async Task<List<LabTestDetailsViewModel>> getAllTestPrescriptionTests(int testId)
        {
            return await _ilabtechrepository.viewTestPrescriptionTests(testId);
        }

        #endregion

        /*
        #region get all bills
        [HttpGet("Bill")]
        //https://localhost:44343/api/labTech/Bill
        public async Task<IActionResult> GetAllBills()
        {
            try
            {
                var bill = await _ilabtechrepository.GetAllTestBills();
                if (bill == null)
                {
                    return NotFound();
                }
                return Ok(bill);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion region
        #region get bill by id
        [HttpGet("TestBill{id}")]
        public async Task<ActionResult<TestBill>> GetTestBillById(int? id)
        {
            try
            {
                ActionResult<TestBill> labbill = await _ilabtechrepository.GetTestBillById(id);
                if (labbill == null)
                {
                    return NotFound();
                }
                return labbill;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region add bill
        [HttpPost("Bill")]
        //https://localhost:44343/api/LabTeCh/Bill
        public async Task<IActionResult> AddToBill([FromBody] TestBill testbill)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var billId = await _ilabtechrepository.AddToTestBill(testbill);
                    if (billId > 0)
                    {
                        return Ok(billId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion
        */


    }
}
