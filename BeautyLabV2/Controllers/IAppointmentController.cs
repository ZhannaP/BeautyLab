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
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _service;

        public AppointmentController(IAppointmentService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AppointmentRequest request)
        {
            var result = await _service.CreateAsync(request);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("client/{clientId:int}")]
        public async Task<IActionResult> GetByClientId(int clientId)
        {
            var result = await _service.GetByClientIdAsync(clientId);
            return Ok(result);
        }

        [HttpGet("master/{masterId:int}")]
        public async Task<IActionResult> GetByMasterId(int masterId)
        {
            var result = await _service.GetByMasterIdAsync(masterId);
            return Ok(result);
        }

        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetByStatus(string status)
        {
            var result = await _service.GetByStatusAsync(status);
            return Ok(result);
        }

        [HttpGet("date/{date}")]
        public async Task<IActionResult> GetByDate(DateTime date)
        {
            var result = await _service.GetByDateAsync(date);
            return Ok(result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] AppointmentRequest request)
        {
            var result = await _service.UpdateAsync(id, request);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return Ok(new { message = "Appointment deleted" });
        }
    }
}
