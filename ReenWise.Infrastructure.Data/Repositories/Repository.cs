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
        internal DbSet<T> dbSet;

        public Repository(ReenWiseDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public virtual IEnumerable<T> List(ISpecification<T> spec)
        {
            // fetch a Queryable that includes all expression-based includes
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(_dbContext.Set<T>().AsQueryable(),
                    (current, include) => current.Include(include));

            // modify the IQueryable to include any string-based include statements
            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            // return the result of the query using the specification's criteria expression
            return secondaryResult
                .Where(spec.Criteria)
                .AsEnumerable();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            var query = _dbContext.Set<T>()
                .Include(_dbContext.GetIncludePaths(typeof(T)));
            var result = await query
                .ToListAsync();
            return result as IEnumerable<T>;
        }

        public virtual async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            _dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var query = _dbContext.Set<T>()
                .Include(_dbContext.GetIncludePaths(typeof(T)));
            if (predicate != null)
                query = query.Where(predicate);
            var result = await query
                .ToListAsync();
            return result;
        }

        public virtual async Task<T> GetById(Guid id)
        {
            return await _dbContext.Set<T>()
                .Include(_dbContext.GetIncludePaths(typeof(T)))
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public virtual async Task<T> Create(T entity)
        {
            var result = await _dbContext.Set<T>().AddAsync(entity);
            //_dbContext.Entry<T>(entity).State = EntityState.Detached;
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public virtual async Task<bool> Update(Guid id, T entity)
        {
            var _entity = await GetById(id);
            if (_entity == null)
            {
               _entity = await Create(entity);
                return _entity != null ? true : false;
            }
            var result = _dbContext.Set<T>().Update(entity);
            //_dbContext.Entry<T>(_entity).State = EntityState.Detached;
            await _dbContext.SaveChangesAsync();
            return result != null ? true : false;
        }

        public virtual async Task<bool> Delete(Guid id)
        {
            var entity = await GetById(id);
            if (entity == null)
                return false;
            var result = _dbContext.Set<T>().Remove(entity);
            //_dbContext.Entry<T>(entity).State = EntityState.Detached;
            await _dbContext.SaveChangesAsync();
            return result != null ? true : false;
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

        public virtual T FindElement(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
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

    public class _Repository<T> : _IRepository<T> where T : EntityBase
    {
        protected readonly DbContext _context;

        public _Repository(DbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        public bool Contains(ISpecification<T> specification = null)
        {
            return Count(specification) > 0 ? true : false;
        }

        public bool Contains(Expression<Func<T, bool>> predicate)
        {
            return Count(predicate) > 0 ? true : false;
        }

        public int Count(ISpecification<T> specification = null)
        {
            return ApplySpecification(specification).Count();
        }

        public int Count(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).Count();
        }

        public IEnumerable<T> Find(ISpecification<T> specification = null)
        {
            return ApplySpecification(specification);
        }

        public T FindById(Guid id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }
    }

}
