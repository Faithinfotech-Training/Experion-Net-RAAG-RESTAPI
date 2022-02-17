using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_Api_Raag.ViewModel
{
    public class AppointmentViewModel
    {
        public int AppoinmentId { get; set; }
        public int? PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TokenNo { get; set; }
        public DateTime? TokenDate { get; set; }
        public string DoctorName { get; set; }
        public int DoctorId { get; set; }
        public int CbillId { get; set; }
        public int? EmployeeId { get; set; }
        public decimal ConsultationFee { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}