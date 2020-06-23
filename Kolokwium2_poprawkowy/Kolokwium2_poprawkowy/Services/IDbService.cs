using Kolokwium2_poprawkowy.DTOs;
using Kolokwium2_poprawkowy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium2_poprawkowy.Services
{
    public interface IDbService
    {
        public ICollection<PetReq> GetPets(int year);
        public ICollection<Pet> GetPets();
        public bool AddPet(AddPetReq req);

    }
}
