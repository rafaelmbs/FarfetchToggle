using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarfetchToggleService.Repository.Views;
using FarfetchToggleService.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace FarfetchToggleService.Controllers
{
    [Route("api/[controller]")]
    public class ToggleController : Controller
    {
        private readonly ToggleService _service;

        public ToggleController(ToggleService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<ToggleView> Get()
        {
            return _service.GetToggles();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var registryId = new ObjectId(id);

            var toggle = _service.GetToggle(registryId);
            if (toggle == null)
            {
                return NotFound();
            }

            return new ObjectResult(toggle);
        }

        [HttpPost]
        public IActionResult Post([FromBody]ToggleView toggle)
        {
            _service.CreateToggle(toggle);
            return new OkObjectResult(toggle);
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody]ToggleView toggle)
        {
            var registryId = new ObjectId(id);
            var toggleReturned = _service.GetToggle(registryId);
            if (toggleReturned == null)
            {
                return NotFound();
            }
            
            _service.UpdateToggle(registryId, toggle);
            return new OkResult();
        }
    }
}
