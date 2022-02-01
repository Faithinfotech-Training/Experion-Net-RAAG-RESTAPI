using System;
using System.Collections.Generic;

namespace CMS_Api_Raag.Models
{
    public partial class Token
    {
        public int TokenNo { get; set; }
        public DateTime? TokenDate { get; set; }
        public int AppointmentId { get; set; }
        public int? DoctorId { get; set; }

        public virtual Appoinment Appointment { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}
