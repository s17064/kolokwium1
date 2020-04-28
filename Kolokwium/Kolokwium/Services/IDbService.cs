using Kolokwium.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Services
{
    public interface IDbService
    {
         List<Prescription> GetAllPresc();
        List<Prescription> GetPresFor(int id);
        string AddMed(int id, List<Medicament> reqlist);
    }
}
