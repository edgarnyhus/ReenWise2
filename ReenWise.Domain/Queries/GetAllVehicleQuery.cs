using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ReenWise.Domain.Dtos;

namespace ReenWise.Domain.Queries
{
    public class GetAllVehicleQuery : IRequest<List<VehicleDto>>
    {
    }
}
