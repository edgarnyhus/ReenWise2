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
    public class GetEquipmentByIdHandler : IRequestHandler<GetEquipmentByIdQuery, EquipmentDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Equipment> _repository;

        public GetEquipmentByIdHandler(IMapper mapper, IRepository<Equipment> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<EquipmentDto> Handle(GetEquipmentByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetById(request.Id);
            return _mapper.Map<Equipment, EquipmentDto>(result);
        }
    }
}
