using System;
using System.Collections.Generic;
using System.Text;

namespace ReenWise.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> Repository<T>() where T : EntityBase;
        int Complete();
    }
}
