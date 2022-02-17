using System;
using System.Collections.Generic;

namespace CMS_Api_Raag.Models
{
    public partial class ConsultationBillDetails
    {
        public int CbillId { get; set; }
        public int? AppointmentId { get; set; }
        public int? EmployeeId { get; set; }
        public decimal ConsultationFee { get; set; }
        public DateTime UpdatedDate { get; set; }

        public virtual Appoinment Appointment { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
