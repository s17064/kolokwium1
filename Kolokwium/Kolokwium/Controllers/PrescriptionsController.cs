using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kolokwium.Models;
using Kolokwium.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium.Controllers
{
    [Route("api/prescriptions")]
    [ApiController]
    public class PrescriptionsController : ControllerBase
    {

        private IDbService _service;

        public PrescriptionsController(IDbService service)
        {
            _service = service;
        }
        // GET: api/Prescriptions
        [HttpGet]
        public IActionResult GetAll()

        {
            var response = _service.GetAllPresc();
            if (response != null) return Ok(response);
            return NotFound("Receptow nie znaliezono");
        }

        // GET: api/Prescriptions/5
        [HttpGet("{id}")]
        public IActionResult GetPreFor(int id)
        {
            var response = _service.GetPresFor(id);
            if (response != null) return Ok(response);
            return NotFound("Takiego pacjenta nie znaleziono");
        }

        // POST: api/Prescriptions
        [HttpPost("{id}/medicaments")]
        public IActionResult Post(int id, List<Medicament> reqlist)
        {
            var response = _service.AddMed(id, reqlist);
            if (response != null) return BadRequest("Zle");
            return Ok(response);
        }

        
    }
}
