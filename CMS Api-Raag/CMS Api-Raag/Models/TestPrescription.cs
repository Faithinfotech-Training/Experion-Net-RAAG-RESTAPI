using System;
using System.Collections.Generic;

namespace CMS_Api_Raag.Models
{
    public partial class TestPrescription
    {
        public TestPrescription()
        {
            TestBill = new HashSet<TestBill>();
            TestDetails = new HashSet<TestDetails>();
        }

        public int TprescriptionId { get; set; }
        public int? DoctorId { get; set; }
        public int? AppointmentId { get; set; }

        public virtual Appoinment Appointment { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual ICollection<TestBill> TestBill { get; set; }
        public virtual ICollection<TestDetails> TestDetails { get; set; }
    }
}
