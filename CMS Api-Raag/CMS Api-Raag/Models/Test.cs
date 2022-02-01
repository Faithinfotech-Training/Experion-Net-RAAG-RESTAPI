using System;
using System.Collections.Generic;

namespace CMS_Api_Raag.Models
{
    public partial class Test
    {
        public Test()
        {
            PrescribedTest = new HashSet<PrescribedTest>();
        }

        public int TestId { get; set; }
        public int? UnitId { get; set; }
        public string TestName { get; set; }
        public string TestType { get; set; }
        public string TestDescription { get; set; }
        public int TestCost { get; set; }

        public virtual TestUnit Unit { get; set; }
        public virtual ICollection<PrescribedTest> PrescribedTest { get; set; }
    }
}
