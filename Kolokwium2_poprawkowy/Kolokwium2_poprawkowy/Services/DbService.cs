using Kolokwium2_poprawkowy.DTOs;
using Kolokwium2_poprawkowy.Models;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium2_poprawkowy.Services
{
    public class DbService : IDbService
    {
        private readonly s17064Context context;

        public DbService(s17064Context con)
        {
            context = con;
        }

        public bool AddPet(AddPetReq req)
        {
            var pet = new AddPetReq
            {
                
               BreedName = req.BreedName,
                Name = req.Name,
                IsMale = req.IsMale,
                DateRegistered = req.DateRegistered,
                ApprocimateDateOfBirth = req.ApprocimateDateOfBirth,
                
                
            };
            var idb = context.BreedType.Where(b => b.Name == pet.BreedName).Select(p=> p.IdBreedType).First();
            var idbool = context.BreedType.Where(b => b.Name == pet.BreedName).Select(p => p.IdBreedType).Any();
            if (!idbool)
            {
                var br = new BreedType
                {
                    IdBreedType = context.BreedType.Max(b => b.IdBreedType) +1,
                    Name = pet.BreedName,
                };
                context.BreedType.Add(br);
            }
            var np = new Pet
            {
                IdPet = context.Pet.Max(p => p.IdPet) + 1,
                IdBreedType = idb,
                Name = pet.Name,
                IsMale = pet.IsMale,
                DateRegistered = pet.DateRegistered,
                ApprocimateDateOfBirth = pet.ApprocimateDateOfBirth
            };
            context.Pet.Add(np);
            context.SaveChanges();
            return true;
        }

        public ICollection<PetReq> GetPets(int year)
        {
            ICollection<PetReq> pets = null;
 
            var pet = context.Pet.Where(p => p.DateRegistered.Year == year).OrderBy(p => p.DateRegistered);

            foreach (var p in pet)
            {
                ICollection<VolPetReq> volunteers = null;
                
                
                    var vol = context.VolunteerPet
               .Include(vp => vp.IdVolunteerNavigation)
               .Where(vp => vp.IdPet == p.IdPet)
               .Select(vp => vp.IdVolunteerNavigation)
               .ToList();
                    foreach(var vl in vol)
                    {
                        var vn = new VolPetReq
                        {
                            Name = vl.Name,
                            Surname = vl.Surname,
                            Phone = vl.Phone
                        };
                        volunteers.Add(vn);
                    }
                    var newP = new PetReq
                    {
                        IdPet = p.IdPet,
                        IdBreedType = p.IdBreedType,
                        Name = p.Name,
                        IsMale = p.IsMale,
                        DateRegistered = p.DateRegistered,
                        ApprocimateDateOfBirth = p.ApprocimateDateOfBirth,
                        DateAdopted = p.DateAdopted,
                        Volunteers = volunteers
                    };
                    pets.Add(newP);
                
                
            }
            return pets;
        }

        public ICollection<Pet> GetPets()
        {
            var res = context.Pet.ToList();
            return res;
        }
    }
}
