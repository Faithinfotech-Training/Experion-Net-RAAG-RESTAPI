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
    }
}
