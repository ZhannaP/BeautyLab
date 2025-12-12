using BLL.Requests;
using BLL.Services.Interfaces;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyLabV2.Controllers
{
    namespace BeautyLab.API.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class ServiceController : ControllerBase
        {
            private readonly IServiceService _service;

            public ServiceController(IServiceService service)
            {
                _service = service;
            }

            // GET: api/service
            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var result = await _service.GetAllAsync();
                return Ok(result);
            }

            // GET: api/service/{id}
            [HttpGet("{id:int}")]
            public async Task<IActionResult> GetById(int id)
            {
                var result = await _service.GetByIdAsync(id);
                if (result == null)
                    return NotFound();

                return Ok(result);
            }

            // GET: api/service/by-name/{name}
            [HttpGet("by-name/{name}")]
            public async Task<IActionResult> GetByName(string name)
            {
                var result = await _service.GetByNameAsync(name);
                if (result == null)
                    return NotFound();

                return Ok(result);
            }

            // GET: api/service/max-duration/{duration}
            [HttpGet("max-duration/{duration:int}")]
            public async Task<IActionResult> GetByMaxDuration(int duration)
            {
                var result = await _service.GetByMaxDurationAsync(duration);
                return Ok(result);
            }

            // POST: api/service
            [HttpPost]
            public async Task<IActionResult> Create([FromBody] ServiceRequest request)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var created = await _service.CreateAsync(request);

                return CreatedAtAction(nameof(GetById), new { id = created.ServiceId }, created);
            }

            // PUT: api/service/{id}
            [HttpPut("{id:int}")]
            public async Task<IActionResult> Update(int id, [FromBody] ServiceRequest request)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _service.UpdateAsync(id, request);
                if (result == null)
                    return NotFound();

                return Ok(result);
            }

            // DELETE: api/service/{id}
            [HttpDelete("{id:int}")]
            public async Task<IActionResult> Delete(int id)
            {
                var success = await _service.DeleteAsync(id);
                if (!success)
                    return NotFound();

                return NoContent();
            }
        }
    }
}
