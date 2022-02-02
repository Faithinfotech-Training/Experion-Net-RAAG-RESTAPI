using CMS_Api_Raag.Models;
using CMS_Api_Raag.Repository;
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
    public class LabTestController : ControllerBase
    {
        // data fields
        public readonly IlabTestRepository _ilabtestrepository;

        // default constructor
        public LabTestController(IlabTestRepository ilabtestrepository)
        {
            _ilabtestrepository = ilabtestrepository;
        }
        #region get all bills
        [HttpGet]
        //https://localhost:44343/api/LabTest
        public async Task<IActionResult> GetAllBills()
        {
            try
            {
                var bill = await _ilabtestrepository.GetAllTestBills();
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
        [HttpGet("{id}")]
        //https://localhost:44343/api/LabTest/3
        public async Task<ActionResult<TestBill>> GetTestBillById(int? id)
        {
            try
            {
                ActionResult<TestBill> labbill = await _ilabtestrepository.GetTestBillById(id);
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
        [HttpPost]
        //https://localhost:44343/api/LabTest
        public async Task<IActionResult> AddToBill([FromBody] TestBill testbill)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var billId = await _ilabtestrepository.AddToTestBill(testbill);
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
    }
}
