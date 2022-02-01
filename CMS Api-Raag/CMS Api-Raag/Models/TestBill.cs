using System;
using System.Collections.Generic;

namespace CMS_Api_Raag.Models
{
    public partial class TestBill
    {
        public int TbillId { get; set; }
        public int? TprescriptionId { get; set; }
        public int? AppointmentId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime UpdatedDate { get; set; }

        public virtual Appoinment Appointment { get; set; }
        public virtual TestPrescription Tprescription { get; set; }
    }
}
