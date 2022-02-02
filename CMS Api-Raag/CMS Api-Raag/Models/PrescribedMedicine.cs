using System;
using System.Collections.Generic;

namespace CMS_Api_Raag.Models
{
    public partial class PrescribedMedicine
    {
        public PrescribedMedicine()
        {
            PrescriptionDetails = new HashSet<PrescriptionDetails>();
        }

        public int Pmid { get; set; }
        public int? MedicineId { get; set; }
        public int? DosageId { get; set; }
        public int? Quantity { get; set; }

        public virtual Dosage Dosage { get; set; }
        public virtual Medicine Medicine { get; set; }
        public virtual ICollection<PrescriptionDetails> PrescriptionDetails { get; set; }
    }
}
