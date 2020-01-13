using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ReenWise.Application.Interfaces;
using ReenWise.Domain.Dtos;
using ReenWise.Domain.Commands;
using ReenWise.Domain.Models.Mirror;
using ReenWise.Domain.Interfaces;
using ReenWise.Domain.Contracts;
using ReenWise.Domain.Queries;
using ReenWise.Domain.Queries.Helpers;

namespace ReenWise.Application.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Equipment> _repository;
        private readonly IMediator _mediator;

        public EquipmentService(IMapper mapper, IRepository<Equipment> repository, IMediator mediator)
        {
            _mapper = mapper;
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<IEnumerable<EquipmentDto>> GetEquipment(EquipmentQueryParameters queryParameters)
        {
            var query = new GetAllEquipmentQuery(queryParameters);
            var result = await _mediator.Send(query);
            return result;
        }
      
        public async Task<EquipmentDto> GetEquipmentById(Guid id)
        {
            var query = new GetEquipmentByIdQuery(id);
            var result = await _mediator.Send(query);
            return result;
        }

        public async Task<EquipmentDto> CreateEquipment(EquipmentContract contract)
        {                
            var command = new CreateEquipmentCommand(contract);
            var result = await _mediator.Send(command);
            return result;
        }

        public async Task<bool> UpdateEquipment(Guid id, EquipmentContract contract)
        {
            var command = new UpdateEquipmentCommand(id, contract);
            var result = await _mediator.Send(command);
            return result;
        }

        public async Task<bool> DeleteEquipment(Guid id)
        {
            var command = new DeleteEquipmentCommand(id);
            var result = await _mediator.Send(command);
            return result;
        }
    }
}
