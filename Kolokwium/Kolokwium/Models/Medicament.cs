using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Models
{
    public class Medicament
    {
        [Required]
        public int idMedicament { get; set; }
        [Required]
        public int Dose { get; set; }
        [Required]
        public string Details { get; set; }
    }
}
