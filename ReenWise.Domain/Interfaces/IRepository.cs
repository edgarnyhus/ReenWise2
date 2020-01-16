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
        //Task<IEnumerable<T>> GetAll();
        //Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate = null);
        Task<IEnumerable<T>> GetAll(ISpecification<T> specification = null);
        Task<T> GetById(Guid id);
        Task<T> Add(T entity);
        Task<bool> AddRange(IEnumerable<T> entities);
        Task<bool> Update(Guid id, T entity);
        Task<bool> Remove(Guid id);
        Task<bool> Remove(T entity);
        Task<bool> RemoveRange(IEnumerable<T> entities);
        Task<bool> Contains(ISpecification<T> specification = null);
        Task<bool> Contains(Expression<Func<T, bool>> predicate);
        Task<int> Count(ISpecification<T> specification = null);
        Task<int> Count(Expression<Func<T, bool>> predicate);
    }

    public abstract class EntityBase
    {
        [Required]
        [StringLength(128)]
        public Guid Id { get; /*protected internal*/ set; }
    }
}
