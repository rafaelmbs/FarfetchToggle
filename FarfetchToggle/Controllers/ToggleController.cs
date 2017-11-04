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

        [SwaggerResponse((int)HttpStatusCode.OK)]
        [HttpGet]
        public IActionResult Get()
        {
            var result = _service.GetToggles();

            return Json(result);
        }

        [SwaggerResponse((int)HttpStatusCode.OK)]
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] ToggleGetByIdRequest request)
        {
            var toggle = _service.GetToggle(request.id);

            if (toggle == null)
            {
                return NotFound();
            }

            return Json(toggle);
        }

        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(TogglePostRequest))]
        [HttpPost]
        public IActionResult Post([FromBody]TogglePostRequest request)
        {
            _service.CreateToggle(request);

            return new OkResult();
        }

        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(TogglePutRequest))]
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] string id, [FromBody]TogglePutRequest request)
        {
            var result = _service.GetToggle(id);

            if (result == null)
            {
                return NotFound();
            }

            _service.UpdateToggle(id, request);
            return new OkResult();
        }
    }
}
