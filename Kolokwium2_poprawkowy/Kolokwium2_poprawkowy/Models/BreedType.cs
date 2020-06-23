using System;
using System.Collections.Generic;

namespace Kolokwium2_poprawkowy.Models
{
    public partial class BreedType
    {
        public BreedType()
        {
            Pet = new HashSet<Pet>();
        }

        public int IdBreedType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Pet> Pet { get; set; }
    }
}
