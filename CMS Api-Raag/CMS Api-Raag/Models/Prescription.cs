using System;
using System.Collections.Generic;

namespace CMS_Api_Raag.Models
{
    public partial class Prescription
    {
        public Prescription()
        {
            MedicineBill = new HashSet<MedicineBill>();
            PrescriptionDetails = new HashSet<PrescriptionDetails>();
        }

        public int PrescriptionId { get; set; }
        public int? AppointmentId { get; set; }
        public int? DoctorId { get; set; }

        public virtual Appoinment Appointment { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual ICollection<MedicineBill> MedicineBill { get; set; }
        public virtual ICollection<PrescriptionDetails> PrescriptionDetails { get; set; }
    }
}
