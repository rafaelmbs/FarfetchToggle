using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FarfetchToggle.Contracts.Message;
using FarfetchToggle.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FarfetchToggle.Controllers
{
    [Route("api/[controller]"), Authorize]
    public class SubscriptionController : Controller
    {
        private readonly MessageService _service;

        public SubscriptionController(MessageService service)
        {
            _service = service;
        }

        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(SubscriptionGetRequest))]
        [HttpGet("{email}")]
        public async Task<IActionResult> Get([FromRoute] SubscriptionGetRequest request)
        {
            var result = await _service.Subscribe(request);

            return Json(new { result });
        }
    }
}
