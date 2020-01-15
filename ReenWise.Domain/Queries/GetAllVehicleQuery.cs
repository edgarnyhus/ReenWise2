using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ReenWise.Domain.Dtos;
using ReenWise.Domain.Models.Mirror;

namespace ReenWise.Domain.Queries
{
    public class GetAllVehicleQuery : IRequest<List<Vehicle>>
    {
    }
}
