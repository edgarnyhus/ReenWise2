using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ReenWise.Domain.Interfaces;
using ReenWise.Infrastructure.Data.Context;
using Z.EntityFramework.Plus;

namespace ReenWise.Infrastructure.Data.Repositories
{
    public class SpecificationEvaluator<T> where T : EntityBase
    {
        protected ReenWiseDbContext _dbContext { get; set; }

        public SpecificationEvaluator(ReenWiseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> specification)
        {
            var query = inputQuery;

            if (specification == null)
                return query;

            // modify the IQueryable using the specification's criteria expression
            if (specification.Criteria != null)
            {
                query = query.Where(specification.Criteria);
            }

            // Includes all expression-based includes
            query = specification.Includes.Aggregate(query,
                (current, include) => current.Include(include));

            // Include any string-based include statements
            query = specification.IncludeStrings.Aggregate(query,
                (current, include) => current.Include(include));

            query = specification.IncludeFilters.Aggregate(query,
                (current, include) => current.IncludeFilter(include));

            // Apply ordering if expressions are set
            if (specification.OrderBy != null)
            {
                query = query.OrderBy(specification.OrderBy);
            }
            else if (specification.OrderByDescending != null)
            {
                query = query.OrderByDescending(specification.OrderByDescending);
            }

            if (specification.GroupBy != null)
            {
                query = query.GroupBy(specification.GroupBy).SelectMany(x => x);
            }

            // Apply paging if enabled
            if (specification.IsPagingEnabled)
            {
                query = query.Skip(specification.Skip)
                    .Take(specification.Take);
            }
            return query;
        }
    }
}
