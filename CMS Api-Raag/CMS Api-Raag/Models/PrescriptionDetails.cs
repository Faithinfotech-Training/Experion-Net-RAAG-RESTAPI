using System;
using System.Collections.Generic;

namespace CMS_Api_Raag.Models
{
    public partial class PrescriptionDetails
    {
        public int PdetailsId { get; set; }
        public int? PrescriptionId { get; set; }
        public int? Pmid { get; set; }

        public virtual PrescribedMedicine Pm { get; set; }
        public virtual Prescription Prescription { get; set; }
    }
}
