using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Models
{
    public class Prescription
    {
        public int idPrescription { get; set; }
        public string Date { get; set; }
        public string DueDate { get; set; }
        public int idPatient { get; set; }
        public int idDoctor { get; set; }
    }
}
