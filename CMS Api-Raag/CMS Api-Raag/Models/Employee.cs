using System;
using System.Collections.Generic;

namespace CMS_Api_Raag.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Admin = new HashSet<Admin>();
            Appoinment = new HashSet<Appoinment>();
            ConsultationBillDetails = new HashSet<ConsultationBillDetails>();
            Doctor = new HashSet<Doctor>();
        }

        public int EmployeeId { get; set; }
        public int? RoleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
        public int PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public DateTime Doj { get; set; }
        public string EmployeeStatus { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Admin> Admin { get; set; }
        public virtual ICollection<Appoinment> Appoinment { get; set; }
        public virtual ICollection<ConsultationBillDetails> ConsultationBillDetails { get; set; }
        public virtual ICollection<Doctor> Doctor { get; set; }
    }
}
