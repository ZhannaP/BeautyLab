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
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _service;

        public PaymentController(IPaymentService service)
        {
            _service = service;
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

        [HttpGet("by-appointment/{appointmentId:int}")]
        public async Task<IActionResult> GetByAppointmentId(int appointmentId)
        {
            var result = await _service.GetByAppointmentIdAsync(appointmentId);
            return Ok(result);
        }

        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetByStatus(string status)
        {
            var result = await _service.GetByStatusAsync(status);
            return Ok(result);
        }

        [HttpGet("total-by-appointment/{appointmentId:int}")]
        public async Task<IActionResult> GetTotalByAppointmentId(int appointmentId)
        {
            var total = await _service.GetTotalPaymentsByAppointmentIdAsync(appointmentId);
            return Ok(total);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PaymentRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _service.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = created.PaymentId }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] PaymentRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.UpdateAsync(id, request);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

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
