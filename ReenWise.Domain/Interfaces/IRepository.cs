using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ReenWise.Domain.Interfaces
{
    public interface IRepository<T> where T : EntityBase
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate = null);

        Task<T> GetById(Guid id);

        Task<T> Create(T entity);

        Task<bool> Update(Guid id, T entity);

        Task<bool> Delete(Guid id);

    }

    public abstract class EntityBase
    {
        [Required]
        [StringLength(128)]
        public Guid Id { get; /*protected internal*/ set; }
    }

    public interface _IRepository<T> where T : class
    {
        T FindById(Guid id);

        IEnumerable<T> Find(ISpecification<T> specification = null);

        void Add(T entity);
        void AddRange(IEnumerable<T> entities);

        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

        void Update(T entity);

        bool Contains(ISpecification<T> specification = null);
        bool Contains(Expression<Func<T, bool>> predicate);

        int Count(ISpecification<T> specification = null);
        int Count(Expression<Func<T, bool>> predicate);
    }

}
