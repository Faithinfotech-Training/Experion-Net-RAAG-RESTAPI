using System;
using System.Collections.Generic;

namespace CMS_Api_Raag.Models
{
    public partial class Patient
    {
        public Patient()
        {
            Appoinment = new HashSet<Appoinment>();
        }

        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime Dob { get; set; }
        public string BloodGroup { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int? Pincode { get; set; }
        public string EmailAddress { get; set; }

        public virtual ICollection<Appoinment> Appoinment { get; set; }
    }
}
