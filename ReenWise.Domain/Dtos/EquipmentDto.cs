using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using ReenWise.Domain.Models;
using ReenWise.Domain.Models.Mirror;

namespace ReenWise.Domain.Dtos
{
    public class EquipmentDto : EntityBaseDto
    {
        public virtual string alias { get; set; }
        public virtual ModelDto model { get; set; }
        public virtual LocationDto location { get; set; }
        public virtual OrganizationDto organization { get; set; }
        public virtual string notes { get; set; }

    }
}
