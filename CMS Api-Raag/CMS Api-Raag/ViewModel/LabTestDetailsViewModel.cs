using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_Api_Raag.ViewModel
{
    public class LabTestDetailsViewModel
    {
        public int AppointmentId { get; set; }
        public int TestId { get; set; }
        public int PrescribedTestId { get; set; }
        public int UnitId { get; set; }
        public string Testname { get; set; }
        public decimal Testvalue { get; set; }
        public string Normalrange { get; set; }
        public string Unit { get; set; }
    }
}
