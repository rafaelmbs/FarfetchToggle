using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
            try
            {
                var result = _service.GetToggles();
                
                return Json(result);
            }
            catch (HttpRequestException httpRequestException)
            {
                return BadRequest(httpRequestException.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var toggle = _service.GetToggle(id);

            if (toggle == null)
            {
                return NotFound();
            }
            
            return Json(toggle);
        }

        [HttpPost]
        public IActionResult Post([FromBody]TogglePostRequest toggle)
        {
            _service.CreateToggle(toggle);
            
            return new OkResult();
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody]TogglePutRequest toggle)
        {
            var result = _service.GetToggle(id);

            if (result == null)
            {
                return NotFound();
            }
            
            _service.UpdateToggle(id, toggle);
            return new OkResult();
        }
    }
}
