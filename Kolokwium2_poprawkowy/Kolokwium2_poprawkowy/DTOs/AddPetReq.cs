using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium2_poprawkowy.DTOs
{
    public class AddPetReq
    {
        public string BreedName { get; set; }
        public string Name { get; set; }
        public bool IsMale { get; set; }
        public DateTime DateRegistered { get; set; }
        public DateTime ApprocimateDateOfBirth { get; set; }
    }
}
