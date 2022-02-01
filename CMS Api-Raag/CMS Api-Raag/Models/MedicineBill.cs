using System;
using System.Collections.Generic;

namespace CMS_Api_Raag.Models
{
    public partial class MedicineBill
    {
        public int MbillId { get; set; }
        public int? PrescriptionId { get; set; }
        public int? AppointmentId { get; set; }
        public decimal MedicinePrice { get; set; }
        public DateTime UpdatedDate { get; set; }

        public virtual Appoinment Appointment { get; set; }
        public virtual Prescription Prescription { get; set; }
    }
}
