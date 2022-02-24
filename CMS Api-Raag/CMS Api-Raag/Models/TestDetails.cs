using System;
using System.Collections.Generic;

namespace CMS_Api_Raag.Models
{
    public partial class TestDetails
    {
        public int Tdid { get; set; }
        public int? TprescriptionId { get; set; }
        public string NormalRange { get; set; }
        public decimal? Result { get; set; }
        public int? Ptid { get; set; }

        public virtual PrescribedTest Pt { get; set; }
        public virtual TestPrescription Tprescription { get; set; }
    }
}
