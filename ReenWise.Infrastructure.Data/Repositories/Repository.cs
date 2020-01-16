using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
            //_dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        //public virtual async Task<IEnumerable<T>> GetAll()
        //{
        //    var query = _dbContext.Set<T>()
        //        .Include(_dbContext.GetIncludePaths(typeof(T)));
        //    var result = await query.ToListAsync();
        //    return result as IEnumerable<T>;
        //}

        //public virtual async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate = null)
        //{
        //    //_dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        //    var query = _dbContext.Set<T>()
        //        .Include(_dbContext.GetIncludePaths(typeof(T)));
        //    if (predicate != null)
        //        query = query.Where(predicate);
        //    var result = await query.ToListAsync();
        //    return result;
        //}

        public virtual async Task<IEnumerable<T>> GetAll(ISpecification<T> specification = null)
        {
            var result = ApplySpecification(specification);
            return await result.ToListAsync();
        }
        //public virtual async Task<IEnumerable<T>> GetAll(ISpecification<T> specification = null)
        //{
        //    // fetch a Queryable that includes all expression-based includes
        //    var queryableResultWithIncludes = specification.Includes
        //        .Aggregate(_dbContext.Set<T>().AsQueryable(),
        //            (current, include) => current.Include(include));

        //    // modify the IQueryable to include any string-based include statements
        //    var secondaryResult = specification.IncludeStrings
        //        .Aggregate(queryableResultWithIncludes,
        //            (current, include) => current.Include(include));

        //    // return the result of the query using the specification's criteria expression
        //    return secondaryResult
        //        .Where(specification.Criteria)
        //        .AsEnumerable();
        //}


        public virtual async Task<T> GetById(Guid id)
        {
            return await _dbContext.Set<T>()
                .Include(_dbContext.GetIncludePaths(typeof(T)))
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public virtual async Task<T> Add(T entity)
        {
            var result = await _dbContext.Set<T>().AddAsync(entity);
            //_dbContext.Entry<T>(entity).State = EntityState.Detached;
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public virtual async Task<bool> AddRange(IEnumerable<T> entities)
        {
            await _dbContext.Set<T>().AddRangeAsync(entities);
            //_dbContext.Entry<T>(entity).State = EntityState.Detached;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public virtual async Task<bool> Update(Guid id, T entity)
        {
            var _entity = await GetById(id);
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
            var entity = await GetById(id);
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

        //public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter = null,
        //    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        //    string includeProperties = "")
        //{
        //    IQueryable<T> query = _dbContext.Set<T>();

        //    if (filter != null)
        //    {
        //        query = query.Where(filter);
        //    }

        //    if (includeProperties != null)
        //    {
        //        foreach (var includeProperty in includeProperties.Split
        //            (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        //        {
        //            query = query.Include(includeProperty);
        //        }
        //    }

        //    var result = new List<T>();
        //    if (orderBy != null)
        //    {
        //        result = await orderBy(query).ToListAsync();
        //    }
        //    else
        //    {
        //        result =  await query.ToListAsync();
        //    }

        //    return result;
        //}

        public IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>().AsQueryable(), spec);
        }

        public T FindElement(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            T item = null;
            using (_dbContext)
            {
                IQueryable<T> query = _dbContext.Set<T>();

                //Apply eager loading
                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                    query = query.Include<T, object>(navigationProperty);

                item = query
                    .FirstOrDefault(where); //Apply where clause
            }

            return item;
        }
    }
}