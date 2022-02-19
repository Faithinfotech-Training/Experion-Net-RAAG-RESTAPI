using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_Api_Raag.ViewModel
{
    public class DoctorViewModel
    {
        public int AppoinmentId { get; set; }
        public int? PatientId { get; set; }
        //public int DoctorId { get; set; }
        //public int DosageId { get; set; }
        //public string Dosage1 { get; set; }
        //public string Remarks { get; set; }
        //public int MedicineId { get; set; }
        //public string MedicineName { get; set; }
        //public int StockQuantity { get; set; }
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //
        //public int Pmid { get; set; }

        //public int Ptid { get; set; }
        //public int? TestId { get; set; }
        //public string BloodGroup { get; set; }
        //public string TestName { get; set; }
        //public string TestType { get; set; }
        //public string TestDescription { get; set; }
        //public int TestCost { get; set; }
        //public int TprescriptionId { get; set; }
        public int TokenNo { get; set; }
        public DateTime? TokenDate { get; set; }
        public string DoctorName { get; set; }
        public int DoctorId { get; set; }

        public int? DepId { get; set; }


    }
}
