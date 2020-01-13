using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ReenWise.Domain.Interfaces;
using ReenWise.Infrastructure.Data.Context;

namespace ReenWise.Infrastructure.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ReenWiseDbContext _context;
        private Hashtable _repositories;

        public UnitOfWork(ReenWiseDbContext context)
        {
            _context = context;
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public IRepository<T> Repository<T>() where T : EntityBase
        {
            if (_repositories == null)
                _repositories = new Hashtable();

            var type = typeof(T).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(Repository<>);

                var repositoryInstance =
                    Activator.CreateInstance(repositoryType
                        .MakeGenericType(typeof(T)), _context);

                _repositories.Add(type, repositoryInstance);
            }

            return (IRepository<T>)_repositories[type];
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
