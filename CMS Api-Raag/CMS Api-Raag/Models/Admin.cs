using System;
using System.Collections.Generic;

namespace CMS_Api_Raag.Models
{
    public partial class Admin
    {
        public Admin()
        {
            Medicine = new HashSet<Medicine>();
        }

        public int AdminId { get; set; }
        public int? EmployeeId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual ICollection<Medicine> Medicine { get; set; }
    }
}
