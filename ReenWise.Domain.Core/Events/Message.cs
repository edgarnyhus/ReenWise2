using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace ReenWise.Domain.Core
{
    public abstract class Message : IRequest<Object>
    {
        public string MessageType { get; protected set; }

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}
