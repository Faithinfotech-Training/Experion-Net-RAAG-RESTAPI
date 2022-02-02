using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_Api_Raag.ViewModel
{
    public class PrescriptionmedicinesViewModel
    {
        public string Medicinename { get; set; }
        public string Dosage { get; set; }
        public int Quantity { get; set; }
        public int PriceperUnit { get; set; }
    }
}
