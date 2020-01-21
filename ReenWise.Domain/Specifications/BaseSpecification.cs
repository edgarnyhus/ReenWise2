using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ReenWise.Domain.Interfaces;
using ReenWise.Domain.Queries.Helpers;

namespace ReenWise.Domain.Specifications
{
    public abstract class BaseSpecification<T> : ISpecification<T>
    {
        protected BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }
        protected BaseSpecification()
        {

        }

        public string Sql { get; set; }
        public Expression<Func<T, bool>> Criteria { get; set; }
        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();
        public List<string> IncludeStrings { get; } = new List<string>();
        public List<Expression<Func<T, object>>> IncludeFilters { get; set; } = new List<Expression<Func<T, object>>>();
        public Expression<Func<T, object>> OrderBy { get; private set; }
        public Expression<Func<T, object>> OrderByDescending { get; private set; }
        public Expression<Func<T, object>> GroupBy { get; private set; }

        public virtual IQueryParameters Parameters { get; set;  }
        public bool WithinSquare { get; set; }
        public bool WithinRadius { get; set; }

        public int Take { get; set; }
        public int Skip { get; set; }
        public bool IsPagingEnabled { get; set; } = false;

        protected virtual void AddSql(string sqlExpression)
        {
            Sql = sqlExpression;
        }

        protected virtual void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        protected virtual void AddInclude(string includeString)
        {
            IncludeStrings.Add(includeString);
        }

        protected virtual void AddIncludeFilter(Expression<Func<T, object>> includeExpression)
        {
            IncludeFilters.Add(includeExpression);
        }

        protected virtual void ApplyPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
            IsPagingEnabled = true;
        }

        protected virtual void ApplyOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        protected virtual void ApplyOrderByDescending(Expression<Func<T, object>> orderByDescendingExpression)
        {
            OrderByDescending = orderByDescendingExpression;
        }

        protected virtual void ApplyGroupBy(Expression<Func<T, object>> groupByExpression)
        {
            GroupBy = groupByExpression;
        }

    }
}
