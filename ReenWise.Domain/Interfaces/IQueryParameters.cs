using System;
using System.Collections.Generic;
using System.Text;

namespace ReenWise.Domain.Interfaces
{
    public interface IQueryParameters
    {
        float Latitude { get; set; }
        float Longitude { get; set; }
        float Distance { get; set; }
        float Radius { get; set; }
        
        // Paging      
        int MaxPageSize { get; set; }
        int PageNumber { get; set; }
        int PageSize { get; set; }
    }
}
