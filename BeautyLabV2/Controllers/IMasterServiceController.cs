using BLL.Requests;
using BLL.Responses;
using BLL.Services.Interfaces;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyLabV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterServiceController : ControllerBase
    {
        private readonly IMasterServiceService _service;

        public MasterServiceController(IMasterServiceService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<MasterServiceResponse>>> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MasterServiceResponse>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet("byMaster/{masterId}")]
        public async Task<ActionResult<List<MasterServiceResponse>>> GetByMasterId(int masterId)
        {
            var result = await _service.GetByMasterIdAsync(masterId);
            return Ok(result);
        }

        [HttpGet("byService/{serviceId}")]
        public async Task<ActionResult<List<MasterServiceResponse>>> GetByServiceId(int serviceId)
        {
            var result = await _service.GetByServiceIdAsync(serviceId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<MasterServiceResponse>> Create([FromBody] MasterServiceRequest request)
        {
            var result = await _service.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = result.MasterServiceId }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MasterServiceResponse>> Update(int id, [FromBody] MasterServiceRequest request)
        {
            var result = await _service.UpdateAsync(id, request);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
