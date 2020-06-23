using Kolokwium2_poprawkowy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium2_poprawkowy.DTOs
{
    public class PetReq
    {
        public int IdPet { get; set; }
        public int IdBreedType { get; set; }
        public string Name { get; set; }
        public bool IsMale { get; set; }
        public DateTime DateRegistered { get; set; }
        public DateTime ApprocimateDateOfBirth { get; set; }
        public DateTime? DateAdopted { get; set; }

        public ICollection<VolPetReq> Volunteers { get; set; }
    }
}
