using System;
using System.Collections.Generic;

namespace CMS_Api_Raag.Models
{
    public partial class DoctorNotes
    {
        public int DnId { get; set; }
        public string Note { get; set; }
        public int? AppointmentId { get; set; }

        public virtual Appoinment Appointment { get; set; }
    }
}
