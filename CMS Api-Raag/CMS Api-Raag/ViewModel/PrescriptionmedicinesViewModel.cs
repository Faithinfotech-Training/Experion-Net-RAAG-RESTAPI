using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_Api_Raag.ViewModel
{
    public class PrescriptionmedicinesViewModel
    {
        public int AppointmentId { get; set; }
        public int MedicineId { get; set; }
        public string Medicinename { get; set; }
        public string Dosage { get; set; }
        public int Quantity { get; set; }
        public decimal PriceperUnit { get; set; }
    }
}
