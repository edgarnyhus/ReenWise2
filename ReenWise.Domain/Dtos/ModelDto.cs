using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ReenWise.Domain.Dtos
{
    public class ModelDto : EntityBaseDto
    {
        public string name { get; set; }
    }
}
