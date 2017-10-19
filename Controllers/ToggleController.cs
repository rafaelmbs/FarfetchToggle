using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarfetchToggleService.Services;
using Microsoft.AspNetCore.Mvc;

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

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return id.ToString();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
