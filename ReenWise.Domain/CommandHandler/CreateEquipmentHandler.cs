using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using ReenWise.Domain.Commands;
using ReenWise.Domain.Contracts;
using ReenWise.Domain.Dtos;
using ReenWise.Domain.Interfaces;
using ReenWise.Domain.Models.Mirror;

namespace ReenWise.Domain.CommandHandler
{
    public class CreateEquipmentHandler : IRequestHandler<CreateEquipmentCommand, Equipment>
    {
        //private readonly IRepository<Equipment> _repository;
        private readonly IEquipmentRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateEquipmentHandler> _logger;

        public CreateEquipmentHandler(IRepository<Equipment> repository, IMapper mapper, ILogger<CreateEquipmentHandler> logger)
        {
            _repository = (IEquipmentRepository) repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Equipment> Handle(CreateEquipmentCommand command, CancellationToken cancellationToken)
        {
            var result = await _repository.Create(command.Equipment);
            return result;
        }
    }
}
