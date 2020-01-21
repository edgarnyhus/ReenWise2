using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NetTopologySuite;
using Z.EntityFramework.Plus;
using ReenWise.Domain.Interfaces;
using ReenWise.Domain.Models.Mirror;
using ReenWise.Infrastructure.Data.Context;
using ReenWise.Infrastructure.Data.Repositories;

namespace ReenWise.Infrastructure.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        protected readonly ReenWiseDbContext _dbContext;

        public Repository(ReenWiseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<IEnumerable<T>> Find(ISpecification<T> specification)
        {
            //https://localhost:44347/api/equipment/withinsquare&distance=100&latitude=67.8798&longitude=12.97759
            var result = ApplySpecification(specification);
            return await result.ToListAsync();
        }

        public virtual async Task<T> FindById(Guid id)
        {
            return await _dbContext.Set<T>()
                .Include(_dbContext.GetIncludePaths(typeof(T)))
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public virtual async Task<T> FindById(ISpecification<T> specification)
        {
            var result = ApplySpecification(specification);
            return await result.FirstOrDefaultAsync();
        }

        public virtual async Task<T> Add(T entity)
        {
            var result = await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public virtual async Task<bool> AddRange(IEnumerable<T> entities)
        {
            await _dbContext.Set<T>().AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public virtual async Task<bool> Update(Guid id, T entity)
        {
            var _entity = await FindById(id);
            if (_entity == null)
            {
                _entity = await Add(entity);
                return _entity != null ? true : false;
            }

            //var result = _dbContext.Set<T>().Update(entity);
            _dbContext.Set<T>().Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public virtual async Task<bool> Remove(Guid id)
        {
            var entity = await FindById(id);
            if (entity == null)
                return false;
            var result = _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
            return result != null ? true : false;
        }

        public virtual async Task<bool> Remove(T entity)
        {
            var result = _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
            return result != null ? true : false;
        }

        public virtual async Task<bool> RemoveRange(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().RemoveRange(entities);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public virtual async Task<bool> Contains(ISpecification<T> specification = null)
        {
            var result = Count(specification);
            return result.Result > 0 ? true : false;
        }

        public async Task<bool> Contains(Expression<Func<T, bool>> predicate)
        {
            var result = Count(predicate);
            return result.Result > 0 ? true : false;
        }

        public async Task<int> Count(ISpecification<T> specification = null)
        {
            return ApplySpecification(specification).Count();
            ;
        }

        public async Task<int> Count(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().Where(predicate).Count();
        }

        public IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>().AsQueryable(), spec);
        }
    }
}