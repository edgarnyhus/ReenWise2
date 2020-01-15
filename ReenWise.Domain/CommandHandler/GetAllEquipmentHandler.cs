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
    public class GetAllEquipmentHandler : IRequestHandler<GetAllEquipmentQuery, List<Equipment>>
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

        public async Task<List<Equipment>> Handle(GetAllEquipmentQuery request, CancellationToken cancellationToken)
        {
            var result =  await _repository.GetAll();
            return (List<Equipment>) result;
        }
    }
}
