using System;
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
    public class GetEquipmentByIdHandler : IRequestHandler<GetEquipmentByIdQuery, Equipment>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Equipment> _repository;
        private readonly ILogger<GetEquipmentByIdHandler> _logger;

        public GetEquipmentByIdHandler(IMapper mapper, IRepository<Equipment> repository, ILogger<GetEquipmentByIdHandler> logger)
        {
            _mapper = mapper;
            _repository = repository;
            _logger = logger;
        }

        public async Task<Equipment> Handle(GetEquipmentByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetById(request.Id);
            return result;
        }
    }
}
