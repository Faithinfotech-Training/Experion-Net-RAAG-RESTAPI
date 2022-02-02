using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_Api_Raag.ViewModel
{
    public class LabTestListViewmodel
    {
        public int AppointmentId { get; set; }
        public string PatientFname { get; set; }
        public string PatientLname { get; set; }
        public string DocttorFname { get; set; }
        public string DocttorLname { get; set; }
        public int TestprescriptionId { get; set; }
        public DateTime? TokenDate { get; set; }
    }
}
