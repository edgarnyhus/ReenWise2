using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ReenWise.Domain.Dtos;
using ReenWise.Domain.Dtos.Helpers;
using ReenWise.Domain.Interfaces;
using ReenWise.Domain.Models.Mirror;
using ReenWise.Domain.Queries;


namespace ReenWise.Domain.CommandHandler
{
    public class GetAllEquipmentHandler : IRequestHandler<GetAllEquipmentQuery, List<EquipmentDto>>
    {
        private readonly IRepository<Equipment> _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllEquipmentHandler> _logger;

        public GetAllEquipmentHandler(IRepository<Equipment> repository, IMapper mapper, ILogger<GetAllEquipmentHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<EquipmentDto>> Handle(GetAllEquipmentQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"GetAllEquipmentHandler: Making query {request.ToString()}");
            var result =  await _repository.GetAll();
            _logger.LogInformation($"GetAllEquipmentHandler: result {result.ToString()}");
            var response = _mapper.Map<List<Equipment>, List<EquipmentDto>>((List<Equipment>)result);
            // Just return one instance of location as defined in EquipmentDto - not an array
            foreach (var entity in result)
            {
                var _locationDto = _mapper.Map<Location, LocationDto>(entity.Locations.FirstOrDefault());
                var _entityDto = response.Find(x => x.id == entity.Id);
                _entityDto.location = _locationDto;
            }
            return response;
        }
    }
}
