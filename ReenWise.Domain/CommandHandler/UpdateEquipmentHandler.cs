using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ReenWise.Domain.Commands;
using ReenWise.Domain.Contracts;
using ReenWise.Domain.Dtos;
using ReenWise.Domain.Interfaces;
using ReenWise.Domain.Models.Mirror;

namespace ReenWise.Domain.CommandHandler
{
    public class UpdateEquipmentHandler : IRequestHandler<UpdateEquipmentCommand, bool>
    {
        private readonly IRepository<Equipment> _repository;
        private readonly IMapper _mapper;

        public UpdateEquipmentHandler(IRepository<Equipment> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<bool> Handle(UpdateEquipmentCommand request, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<EquipmentContract, Equipment>(request.EquipmentContract);
            var result = await _repository.Update(request.Id, command);
            //_logger.LogInformation($"Created equipment: {equipment.id}");
            return result;
        }
    }
}
