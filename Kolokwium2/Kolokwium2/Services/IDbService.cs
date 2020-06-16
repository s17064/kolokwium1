using Kolokwium2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium2.Services
{
    public interface IDbService<T>
    {
        public IEnumerable<T> GetMusician(int id);
    }
}
