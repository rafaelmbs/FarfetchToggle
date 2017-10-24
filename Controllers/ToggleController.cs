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
            var recId = new ObjectId(id);

            var toggle = _service.GetToggle(recId);
            if (toggle == null)
            {
                return NotFound();
            }

            return new ObjectResult(toggle);
        }

        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
    }
}
