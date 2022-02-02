using System;
using System.Collections.Generic;

namespace CMS_Api_Raag.Models
{
    public partial class PrescribedTest
    {
        public PrescribedTest()
        {
            TestDetails = new HashSet<TestDetails>();
        }

        public int Ptid { get; set; }
        public int? TestId { get; set; }
        public int? UnitId { get; set; }
        public string NormalValue { get; set; }
        public decimal Result { get; set; }
        public virtual Test Test { get; set; }
        public virtual TestUnit Unit { get; set; }
        public virtual ICollection<TestDetails> TestDetails { get; set; }
    }
}
