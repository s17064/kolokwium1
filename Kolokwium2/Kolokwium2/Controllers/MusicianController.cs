using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kolokwium2.Models;
using Kolokwium2.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kolokwium2.Controllers
{
    [Route("api/musicians")]
    [ApiController]
    public class MusicianController : ControllerBase
    {
        private readonly IDbService<Musician> _dbservice;

        public MusicianController(IDbService<Musician> dbs)
        {
            _dbservice = dbs;
        } 
  

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            //_dbservice.GetMusician(id);
            return Ok(_dbservice.GetMusician(id));
        }

        // POST api/<MusicianController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MusicianController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MusicianController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
