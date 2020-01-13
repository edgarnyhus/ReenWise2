using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReenWise.Domain.Dtos;
using ReenWise.Application.Interfaces;
using ReenWise.Domain.Contracts;

namespace ReenWise.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        // GET: api/Vehicle
        [Route("~/api/Vehicle")]
        [HttpGet]
        public async Task<IActionResult> GetVehicles()
        {
            var result = await _vehicleService.GetVehicles();
            return Ok(result);
        }

        // GET: api/Vehicle/<id>
        [Route("~/api/Vehicle/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetVehicleById(Guid id)
        {
            var result = await _vehicleService.GetVehicleById(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        // POST: api/Vehicle
        [Route("~/api/Vehicle")]
        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] VehicleContract contract)
        {
            var result = await _vehicleService.CreateVehicle(contract);
            return Ok(result);
        }

        // PUT: api/Vehicle/<id>
        [Route("~/api/Vehicle/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateVehicle(Guid id, [FromBody] VehicleContract contract)
        {
            var result = await _vehicleService.UpdateVehicle(id, contract);
            return result ? (IActionResult)Ok("Vehicle updated") : (IActionResult)BadRequest("Updating entity failed");
        }

        // DELETE: api/ApiWithActions/<id>
        [Route("~/api/Vehicle/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteVehicle(Guid id)
        {
            var result = await _vehicleService.DeleteVehicle(id);
            return result ? (IActionResult)Ok("Vehicle deleted") : NotFound();
        }
    }
}
