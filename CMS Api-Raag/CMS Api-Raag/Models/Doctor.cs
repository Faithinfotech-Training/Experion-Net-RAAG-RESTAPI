using System;
using System.Collections.Generic;

namespace CMS_Api_Raag.Models
{
    public partial class Doctor
    {
        public Doctor()
        {
            Prescription = new HashSet<Prescription>();
            TestPrescription = new HashSet<TestPrescription>();
            Token = new HashSet<Token>();
        }

        public int DoctorId { get; set; }
        public int? DepId { get; set; }
        public int? EmployeeId { get; set; }

        public virtual Department Dep { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<Prescription> Prescription { get; set; }
        public virtual ICollection<TestPrescription> TestPrescription { get; set; }
        public virtual ICollection<Token> Token { get; set; }
    }
}
