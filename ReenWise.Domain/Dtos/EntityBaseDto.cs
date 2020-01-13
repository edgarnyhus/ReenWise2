using System;
using System.Collections.Generic;
using System.Text;

namespace ReenWise.Domain.Dtos
{
    public abstract class EntityBaseDto
    {
        public Guid id { get; protected internal set; }
    }
}
