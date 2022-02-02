using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_Api_Raag.ViewModel
{
    public class ConsultationBillViewModel
    {
        public int CbillId { get; set; }
        public int? AppointmentId { get; set; }
        public string FirstName { get; set; }
        public int? DoctorId { get; set; }
        public decimal ConsultationFee { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
