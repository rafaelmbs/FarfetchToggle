using System;
using System.Net;
using FarfetchToggle.Contracts.Toggle;
using FarfetchToggle.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FarfetchToggle.Controllers
{
    [Route("api/[controller]"), Authorize]
    public class ToggleController : Controller
    {
        private readonly ToggleService _service;

        public ToggleController(ToggleService service)
        {
            _service = service;
        }

        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ToggleGetResponse))]
        [HttpGet]
        public IActionResult Get()
        {
            var result = _service.GetToggles();

            return Json(result);
        }

        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ToggleGetByIdResponse))]
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

        [SwaggerResponse((int)HttpStatusCode.OK)]
        [HttpPost]
        public IActionResult Post([FromBody]TogglePostRequest toggle)
        {
            _service.CreateToggle(toggle);

            return new OkResult();
        }

        [SwaggerResponse((int)HttpStatusCode.OK)]
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
