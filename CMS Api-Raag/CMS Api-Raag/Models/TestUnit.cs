using System;
using System.Collections.Generic;

namespace CMS_Api_Raag.Models
{
    public partial class TestUnit
    {
        public TestUnit()
        {
            PrescribedTest = new HashSet<PrescribedTest>();
            Test = new HashSet<Test>();
        }

        public int UnitId { get; set; }
        public string Unit { get; set; }
        public string Remarks { get; set; }

        public virtual ICollection<PrescribedTest> PrescribedTest { get; set; }
        public virtual ICollection<Test> Test { get; set; }
    }
}
