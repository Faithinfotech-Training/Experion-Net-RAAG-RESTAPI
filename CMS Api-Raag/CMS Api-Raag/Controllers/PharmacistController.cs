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
    public class PharmacistController : ControllerBase
    {
        // data fields
        public readonly IPharmacistRepository _ipharmacistRepository;

        // default constructor
        public PharmacistController(IPharmacistRepository ipharmacistRepository)
        {
            _ipharmacistRepository = ipharmacistRepository;
        }
        #region prescription list
        [HttpGet("prescriptionLists")]
        //https://localhost:44343/api/Pharmacist/prescriptionLists
        public async Task<IActionResult> getAllPrescriptions()
        {
            try
            {
                var viewData = await _ipharmacistRepository.viewPrescriptions();
                if(viewData == null)
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
        [HttpGet("prescription-medcines")]
        //https://localhost:44343/api/Pharmacist/prescription-medcines?presId=2
        public async Task<List<PrescriptionmedicinesViewModel>> getAllPrescriptionMedicines(int presId)
        {
            return await _ipharmacistRepository.viewPrescriptionMedicines(presId);
        }

        #endregion
        #region get all bills
        [HttpGet("Bill")]
        //https://localhost:44343/api/Pharmacist/Bill
        public async Task<IActionResult> GetAllBills()
        {
            try
            {
                var bill = await _ipharmacistRepository.GetAllMedicineBills();
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
        #region add bill
        [HttpPost("Bill")]
        //https://localhost:44343/api/Pharmacist/Bill
        public async Task<IActionResult> AddToBill([FromBody] MedicineBill medicinebill)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var billId = await _ipharmacistRepository.AddToMedicineBill(medicinebill);
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
