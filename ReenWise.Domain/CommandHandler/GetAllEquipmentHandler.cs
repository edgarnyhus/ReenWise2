using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
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

        public GetAllEquipmentHandler(IRepository<Equipment> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<EquipmentDto>> Handle(GetAllEquipmentQuery request, CancellationToken cancellationToken)
        {
            var result =  await _repository.GetAll();
            var response = _mapper.Map<List<Equipment>, List<EquipmentDto>>((List<Equipment>)result);
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
