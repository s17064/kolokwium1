using System;
using System.Collections.Generic;

namespace Kolokwium2_poprawkowy.Models
{
    public partial class Pet
    {
        public Pet()
        {
            VolunteerPet = new HashSet<VolunteerPet>();
        }

        public int IdPet { get; set; }
        public int IdBreedType { get; set; }
        public string Name { get; set; }
        public bool IsMale { get; set; }
        public DateTime DateRegistered { get; set; }
        public DateTime ApprocimateDateOfBirth { get; set; }
        public DateTime? DateAdopted { get; set; }

        public virtual BreedType IdBreedTypeNavigation { get; set; }
        public virtual ICollection<VolunteerPet> VolunteerPet { get; set; }
    }
}
