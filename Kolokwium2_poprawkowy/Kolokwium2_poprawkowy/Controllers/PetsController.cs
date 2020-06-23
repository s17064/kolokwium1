using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kolokwium2_poprawkowy.DTOs;
using Kolokwium2_poprawkowy.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kolokwium2_poprawkowy.Controllers
{
    [Route("api/pets")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IDbService _dbservice;

        public PetsController(IDbService dbs)
        {
            _dbservice = dbs;
        }
        // GET: api/<PetsController>
        [HttpGet]
        public IActionResult GetPets()
        {
            return Ok(_dbservice.GetPets());
        }

        // GET api/<PetsController>/5
        [HttpGet("{id}")]
        public IActionResult GetPets(int year)
        {
            return Ok(_dbservice.GetPets(year));
        }

        // POST api/<PetsController>
        [HttpPost]
        public IAcationResult Post(AddPetReq req)
        {
            _dbservice.AddPet(req);
            return Ok("zostalo dodane");
        }

        // PUT api/<PetsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PetsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
