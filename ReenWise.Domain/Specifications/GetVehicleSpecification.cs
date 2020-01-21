using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ReenWise.Domain.Interfaces;
using ReenWise.Domain.Models.Mirror;
using ReenWise.Domain.Specifications;

namespace ReenWise.Domain.Specifications
{
    public class GetVehicleSpecification : BaseSpecification<Vehicle>
    {
        //public Guid Id { get; }
        public GetVehicleSpecification() : base()
        {
            AddInclude(x => x.Model);
            AddInclude(x => x.LicensePlate);
            AddInclude(x => x.Organization);
            AddInclude(x => x.Locations);
            //AddInclude($"{nameof(Equipment.Model)},{nameof(Equipment.Organization)},{nameof(Equipment.Locations)}");
        }

        public GetVehicleSpecification(Guid id) : base(x => x.Id == id)
        {
            //Id = id;
            AddInclude(x => x.Model);
            AddInclude(x => x.LicensePlate);
            AddInclude(x => x.Organization);
            AddInclude(x => x.Locations);
            //AddInclude($"{nameof(Equipment.Model)},{nameof(Equipment.Organization)},{nameof(Equipment.Locations)}");
        }
    }
}
