using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ReenWise.Domain.Interfaces;
using ReenWise.Domain.Models.Mirror;
using ReenWise.Domain.Specifications;

namespace ReenWise.Domain.Specifications
{
    public class GetAllEquipmentSpecification : BaseSpecification<Equipment>
    {
        public GetAllEquipmentSpecification() : base()
        {
            AddInclude(x => x.Model);
            AddInclude(x => x.Organization);
            AddInclude(x => x.Locations);
            //AddInclude($"{nameof(Equipment.Model)},{nameof(Equipment.Organization)},{nameof(Equipment.Locations)}");
        }

        public GetAllEquipmentSpecification(Guid id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Model);
            AddInclude(x => x.Organization);
            AddInclude(x => x.Locations);
            //AddInclude($"{nameof(Equipment.Model)},{nameof(Equipment.Organization)},{nameof(Equipment.Locations)}");
        }
    }
}
