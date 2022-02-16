using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_Api_Raag.ViewModel
{
    public class DoctorListViewModel
    {

        public int DoctorId { get; set; }
        public int? DepId { get; set; }
        public string DepName { get; set; }
        public int? EmployeeId { get; set; }
        public string FirstName { get; set; }
    }

}