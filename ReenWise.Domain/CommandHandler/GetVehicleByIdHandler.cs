using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ReenWise.Domain.Dtos;
using ReenWise.Domain.Interfaces;
using ReenWise.Domain.Models.Mirror;
using ReenWise.Domain.Queries;

namespace ReenWise.Domain.CommandHandler
{
    public class GetVehicleByIdHandler : IRequestHandler<GetVehicleByIdQuery, VehicleDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Vehicle> _repository;

        public GetVehicleByIdHandler(IMapper mapper, IRepository<Vehicle> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<VehicleDto> Handle(GetVehicleByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetById(request.Id);
            return _mapper.Map<Vehicle, VehicleDto>(result);
        }
    }

}
