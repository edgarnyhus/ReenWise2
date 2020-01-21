using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using NetTopologySuite;
using ReenWise.Domain.Interfaces;
using ReenWise.Domain.Models.Mirror;
using ReenWise.Domain.Specifications;

namespace ReenWise.Domain.Specifications
{
    public class GetEquipmentSpecification : BaseSpecification<Equipment>
    {
        //public IQueryParameters Param { get; set; }

        //public Guid Id { get; }
        public GetEquipmentSpecification(IQueryParameters parameters) : base()
        {
            AddInclude(x => x.Model);
            AddInclude(x => x.Organization);
            AddInclude(x => x.Locations);
            //AddInclude($"{nameof(Equipment.Model)},{nameof(Equipment.Organization)},{nameof(Equipment.Locations)}");
            WithinRadius = parameters.Radius != 0;
            WithinSquare = parameters.Distance != 0;
            Parameters = parameters;

            if (WithinRadius)
            {
                // assuming a spherical approximation of the figure of the Earth with radius R=6371 km
                var R = 6371;
                var r = Parameters.Radius / R; // the angular radius of the query circle
                var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
                var location = geometryFactory.CreatePoint(new NetTopologySuite.Geometries.Coordinate(Parameters.Latitude, Parameters.Longitude));

                Criteria = (c => c.Location.Distance(location) < r);
                
            }
            else if (WithinSquare)
            {
                // assuming a spherical approximation of the figure of the Earth with radius R=6371 km
                var R = 6371;
                var r = Parameters.Distance / R; // the angular radius of the query circle
                var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
                var location = geometryFactory.CreatePoint(new NetTopologySuite.Geometries.Coordinate(Parameters.Latitude, Parameters.Longitude));

                //AddIncludeFilter(c => c.Location.Distance(location) < r);
                Criteria = (c => c.Location.Distance(location) < r);
            }

            Take = parameters.PageSize;
            Skip = parameters.PageNumber * parameters.PageSize;
            IsPagingEnabled = Take > 0;
        }

        public GetEquipmentSpecification(Guid id) : base(x => x.Id == id)
        {
            //Id = id;
            AddInclude(x => x.Model);
            AddInclude(x => x.Organization);
            AddInclude(x => x.Locations);
            //AddInclude($"{nameof(Equipment.Model)},{nameof(Equipment.Organization)},{nameof(Equipment.Locations)}");
        }
    }
}
