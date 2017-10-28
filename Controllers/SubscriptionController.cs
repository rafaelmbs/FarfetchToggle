using FarfetchToggleService.Services;
using Microsoft.AspNetCore.Mvc;

namespace FarfetchToggleService.Controllers
{
    [Route("api/[controller]")]
    public class SubscriptionController : Controller
    {
        private readonly MessageService _service;

        public SubscriptionController(MessageService service)
        {
            _service = service;
        }

        [HttpGet("{email}")]
        public IActionResult Get(string email)
        {
            var result = _service.Subscribe(email);

            return new ObjectResult(result);
        }
    }
}