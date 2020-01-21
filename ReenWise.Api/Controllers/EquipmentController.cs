using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ReenWise.Application.Interfaces;
using ReenWise.Domain.CommandHandler;
using ReenWise.Domain.Contracts;
using ReenWise.Domain.Dtos;
using ReenWise.Domain.Models;
using ReenWise.Domain.Queries.Helpers;

namespace ReenWise.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentService _equipmentService;
        private readonly ILogger<EquipmentController> _logger;

        public EquipmentController(IEquipmentService equipmentService, ILogger<EquipmentController> logger)
        {
            _equipmentService = equipmentService;
            _logger = logger;
        }

        // GET: api/Equipment
        [Route("~/api/Equipment")]
        [HttpGet]
        public async Task<IActionResult> GetEquipment([FromQuery] QueryParameters queryParameters)
        {
            _logger.LogInformation($"EquipmentController: GET equipment with parameters={queryParameters.ToString()}");

            var result = await _equipmentService.GetEquipment(queryParameters);
            var metadata = new
            {
                //result.TotalCount,
                //result.PageSize,
                //result.CurrentPage,
                //result.TotalPages,
                //result.HasNext,
                //result.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            //_logger.LogInfo($"Returned {result.TotalCount} equipment from database.");

            return Ok(result);
        }

        // GET: api/equipment/<id>
        [Route("~/api/Equipment/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetEquipmentById(Guid id)
        {
            var result = await _equipmentService.GetEquipmentById(id);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        // GET: api/Equipment/WithinSquare
        [Route("~/api/Equipment/WithinSquare")]
        [HttpGet]
        public async Task<IActionResult> GetEquipmentWithinSquare([FromQuery] QueryParameters queryParameters)
        {
            var result = await _equipmentService.GetEquipment(queryParameters);
            var metadata = new
            {
                //result.TotalCount,
                //result.PageSize,
                //result.CurrentPage,
                //result.TotalPages,
                //result.HasNext,
                //result.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            //_logger.LogInfo($"Returned {result.TotalCount} equipment from database.");

            return Ok(result);
        }

        // POST: api/equipment
        [Route("~/api/Equipment")]
        [HttpPost]
        public async Task<IActionResult> CreateEquipment([FromBody] EquipmentContract contract)
        {
            var result = await _equipmentService.CreateEquipment(contract);
            return Ok(result);
        }

        // PUT: api/equipment/<id>
        [Route("~/api/Equipment/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateEquipment(Guid id, [FromBody] EquipmentContract contract)
        {
            var result = await _equipmentService.UpdateEquipment(id, contract);
            if (!result)
                return NotFound();
            return Ok("Equipment updated");
        }

        // DELETE: api/equipment/<id>
        [Route("~/api/Equipment/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteEquipment(Guid id)
        {
            var result = await _equipmentService.DeleteEquipment(id);
            if (!result)
                return NotFound();
            return Ok("Equipment deleted");
        }
    }
}
