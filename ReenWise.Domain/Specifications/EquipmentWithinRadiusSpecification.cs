using System;
using System.Collections.Generic;
using System.Text;
using ReenWise.Domain.Models.Mirror;

namespace ReenWise.Domain.Specifications
{
    public class EquipmentWithinRadiusSpecification : BaseSpecification<Equipment>
    {
        public EquipmentWithinRadiusSpecification() : base()
        {
            //AddInclude(x => x.Radius);
            //AddInclude($"{nameof(Equipment.location)}.{nameof(Location.latitude)}");
        }

        public EquipmentWithinRadiusSpecification(Guid id) : base(x => x.Id == id)
        {
            //AddInclude(x => x.Radius);
            //AddInclude($"{nameof(Equipment.location)}.{nameof(Location.latitude)}");
        }
    }
}
