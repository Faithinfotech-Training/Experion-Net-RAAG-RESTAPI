using System;
using System.Collections.Generic;

namespace CMS_Api_Raag.Models
{
    public partial class Medicine
    {
        public Medicine()
        {
            PrescribedMedicine = new HashSet<PrescribedMedicine>();
        }

        public int MedicineId { get; set; }
        public int? AdminId { get; set; }
        public string MedicineName { get; set; }
        public int StockQuantity { get; set; }
        public int UnitPrice { get; set; }
        public DateTime ExpiryDate { get; set; }

        public virtual Admin Admin { get; set; }
        public virtual ICollection<PrescribedMedicine> PrescribedMedicine { get; set; }
    }
}
