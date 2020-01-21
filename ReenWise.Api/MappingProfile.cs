using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ReenWise.Domain.Dtos;
using ReenWise.Domain.Commands;
using ReenWise.Domain.Contracts;
using ReenWise.Domain.Models.Mirror;

namespace ReenWise.Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Organization, OrganizationDto>()
                .ReverseMap();
            CreateMap<OrganizationContract, Organization>()
                .ReverseMap();
            CreateMap<Driver, DriverDto>()
                .ReverseMap();
            CreateMap<DriverContract, Driver>()
                .ReverseMap();
            CreateMap<Equipment, EquipmentDto>().ForMember(x => x.location, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<EquipmentContract, Equipment>().ForMember(x => x.Location, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<LicensePlate, LicensePlateDto>()
                .ReverseMap();
            CreateMap<LicensePlateContract, LicensePlate>()
                .ReverseMap();
            CreateMap<Location, LocationDto>()
                .ReverseMap();
            CreateMap<LocationContract, Location>()
                .ReverseMap();
            CreateMap<Manufacturer, ManufacturerDto>()
                .ReverseMap();
            CreateMap<ManufacturerContract, Manufacturer>()
                .ReverseMap();
            CreateMap<Model, ModelDto>()
                .ReverseMap();
            CreateMap<ModelContract, Model>()
                .ReverseMap();
            CreateMap<OdoMeter, OdoMeterDto>()
                .ReverseMap();
            CreateMap<OdoMeterContract, OdoMeter>()
                .ReverseMap();
            CreateMap<OperatingHours, OperatingHoursDto>()
                .ReverseMap();
            CreateMap<OperatingHoursContract, OperatingHours>()
                .ReverseMap();
            CreateMap<Temperature, TemperatureDto>()
                .ReverseMap();
            CreateMap<TemperatureContract, Temperature>()
                .ReverseMap();
            CreateMap<Unit, UnitDto>()
                .ReverseMap();
            CreateMap<UnitContract, Unit>()
                .ReverseMap();
            CreateMap<Vehicle, VehicleDto>().ForMember(x => x.location, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<VehicleContract, Vehicle>().ForMember(x => x.Location, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
