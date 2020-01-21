using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ReenWise.Domain.Interfaces
{
    //public interface ISpecification<T>
    //{
    //    Expression<Func<T, bool>> Criteria { get; }
    //    List<Expression<Func<T, object>>> Includes { get; }
    //    List<string> IncludeStrings { get; }
    //}

    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
        string Sql { get; set; }
        List<Expression<Func<T, object>>> Includes { get; }
        List<string> IncludeStrings { get; }
        List<Expression<Func<T, object>>> IncludeFilters { get; set;  }
        Expression<Func<T, object>> OrderBy { get; }
        Expression<Func<T, object>> OrderByDescending { get; }
        Expression<Func<T, object>> GroupBy { get; }

        IQueryParameters Parameters { get; }
        bool WithinSquare { get; set; }
        bool WithinRadius { get; set; }

        int Take { get; }
        int Skip { get; }
        bool IsPagingEnabled { get; }
    }
}
