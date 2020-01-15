using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ReenWise.Domain.Dtos;
using ReenWise.Domain.Interfaces;
using ReenWise.Domain.Models.Mirror;
using ReenWise.Domain.Queries;

namespace ReenWise.Domain.CommandHandler
{
    public class GetAllVehicleHandler : IRequestHandler<GetAllVehicleQuery, List<Vehicle>>
    {
        private readonly IRepository<Vehicle> _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllVehicleHandler> _logger;

        public GetAllVehicleHandler(IRepository<Vehicle> repository, IMapper mapper, ILogger<GetAllVehicleHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<Vehicle>> Handle(GetAllVehicleQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAll();
            return (List<Vehicle>)result;
        }
    }
}
