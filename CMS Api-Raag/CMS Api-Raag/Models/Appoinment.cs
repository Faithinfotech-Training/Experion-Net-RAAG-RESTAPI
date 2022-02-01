using System;
using System.Collections.Generic;

namespace CMS_Api_Raag.Models
{
    public partial class Appoinment
    {
        public Appoinment()
        {
            ConsultationBillDetails = new HashSet<ConsultationBillDetails>();
            MedicineBill = new HashSet<MedicineBill>();
            Prescription = new HashSet<Prescription>();
            TestBill = new HashSet<TestBill>();
            TestPrescription = new HashSet<TestPrescription>();
            Token = new HashSet<Token>();
        }

        public int AppointmentId { get; set; }
        public int? PatientId { get; set; }
        public int? EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual ICollection<ConsultationBillDetails> ConsultationBillDetails { get; set; }
        public virtual ICollection<MedicineBill> MedicineBill { get; set; }
        public virtual ICollection<Prescription> Prescription { get; set; }
        public virtual ICollection<TestBill> TestBill { get; set; }
        public virtual ICollection<TestPrescription> TestPrescription { get; set; }
        public virtual ICollection<Token> Token { get; set; }
    }
}
