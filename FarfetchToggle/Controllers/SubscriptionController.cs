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

        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(SubscriptionGetResponse))]
        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email)
        {
            try
            {
                var result = await _service.Subscribe(email);

                return Json(new { result });
            }
            catch (HttpRequestException httpRequestException)
            {
                return BadRequest(httpRequestException.Message);
            }
        }
    }
}
