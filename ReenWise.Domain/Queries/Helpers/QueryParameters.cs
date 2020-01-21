using System;
using System.Collections.Generic;
using System.Text;
using ReenWise.Domain.Interfaces;

namespace ReenWise.Domain.Queries.Helpers
{
    public class QueryParameters : IQueryParameters
    {
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public float Distance { get; set; }
        public float Radius { get; set; }

        // Paging      
        public int MaxPageSize { get; set; } = 1000;
        public int PageNumber { get; set; } = 0;
        private int _pageSize { get; set; } = 500;
        public int PageSize {
            get { return _pageSize; }
            set {
                _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
            }
        }
    }
}