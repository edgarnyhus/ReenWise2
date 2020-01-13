using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ReenWise.Domain.Core.Commands;

namespace ReenWise.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        public  Task SendCommand<T>(IRequest<T> command);
    }
}
