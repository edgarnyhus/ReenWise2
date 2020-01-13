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
    public class GetAllVehicleHandler : IRequestHandler<GetAllVehicleQuery, List<VehicleDto>>
    {
        private readonly IRepository<Vehicle> _repository;
        private readonly IMapper _mapper;

        public GetAllVehicleHandler(IRepository<Vehicle> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<VehicleDto>> Handle(GetAllVehicleQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAll();
            return _mapper.Map<List<Vehicle>, List<VehicleDto>>((List<Vehicle>)result);
        }
    }
}
