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
    public class MedicinebillController : ControllerBase
    {
        // data fields
        public readonly IMedicineBillRepository _imedicinebill;

        // default constructor
        public MedicinebillController(IMedicineBillRepository imedicinebill)
        {
            _imedicinebill = imedicinebill;
        }
        #region get all bills
        [HttpGet]
        //https://localhost:44343/api/Medicinebill
        public async Task<IActionResult> GetAllBills()
        {
            try
            {
                var bill = await _imedicinebill.GetAllMedicineBills();
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
        //https://localhost:44343/api/Medicinebill/3
        public async Task<ActionResult<MedicineBill>> MedicineBillById(int? id)
        {
            try
            {
                var bill = await _imedicinebill.GetMedicineBillById(id);
                if (bill == null)
                {
                    return NotFound();
                }
                return bill;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion
        #region add bill
        [HttpPost]
        //https://localhost:44343/api/Medicinebill
        public async Task<IActionResult> AddToBill([FromBody] MedicineBill medicinebill)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var billId = await _imedicinebill.AddToMedicineBill(medicinebill);
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
