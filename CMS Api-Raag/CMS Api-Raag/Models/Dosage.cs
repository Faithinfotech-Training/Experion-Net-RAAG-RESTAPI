using System;
using System.Collections.Generic;

namespace CMS_Api_Raag.Models
{
    public partial class Dosage
    {
        public Dosage()
        {
            PrescribedMedicine = new HashSet<PrescribedMedicine>();
        }

        public int DosageId { get; set; }
        public string Dosage1 { get; set; }
        public string Remarks { get; set; }

        public virtual ICollection<PrescribedMedicine> PrescribedMedicine { get; set; }
    }
}
