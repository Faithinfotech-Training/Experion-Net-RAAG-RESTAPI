using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_Api_Raag.ViewModel
{
    public class AppointmentViewModel
    {
        public int AppointmentId { get; set; }
        public int? PatientId { get; set; }
        public int DoctorId { get; set; }
        public int DepId { get; set; }
        public string DepName { get; set; }
        public decimal ConsultationFee { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
