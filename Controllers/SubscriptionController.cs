using System.Net.Http;
using System.Threading.Tasks;
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