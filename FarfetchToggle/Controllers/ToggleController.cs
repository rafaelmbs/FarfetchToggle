using System;
using FarfetchToggle.Contracts.Toggle;
using FarfetchToggle.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FarfetchToggle.Controllers
{
    [Route("api/[controller]")]
    public class ToggleController : Controller
    {
        private readonly ToggleService _service;

        public ToggleController(ToggleService service)
        {
            _service = service;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            var result = _service.GetToggles();

            return Json(result);
        }

        [Authorize]
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

        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody]TogglePostRequest toggle)
        {
            _service.CreateToggle(toggle);

            return new OkResult();
        }

        [Authorize]
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
