using System;
using System.Collections.Generic;

namespace CMS_Api_Raag.Models
{
    public partial class Department
    {
        public Department()
        {
            Doctor = new HashSet<Doctor>();
        }

        public int DepId { get; set; }
        public string DepName { get; set; }

        public virtual ICollection<Doctor> Doctor { get; set; }
    }
}
