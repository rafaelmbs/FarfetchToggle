using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarfetchToggleService.Contracts;
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
        public IActionResult Get()
        {
            var result = _service.GetToggles();

            return new ObjectResult(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var toggle = _service.GetToggle(Int32.Parse(id));

            if (toggle == null)
            {
                return NotFound();
            }
            
            return new ObjectResult(toggle);
        }

        [HttpPost]
        public IActionResult Post([FromBody]TogglePostRequest toggle)
        {
            var obj = _service.GetToggle(toggle.ToggleId);

            if (obj == null)
            {
                _service.CreateToggle(toggle);
            }
            else
            {
                return new BadRequestResult();
            }
            
            return new OkResult();
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody]TogglePutRequest toggle)
        {
            var toggleReturned = _service.GetToggle(Int32.Parse(id));

            if (toggleReturned == null)
            {
                return NotFound();
            }
            
            _service.UpdateToggle(Int32.Parse(id), toggle);
            return new OkResult();
        }
    }
}
