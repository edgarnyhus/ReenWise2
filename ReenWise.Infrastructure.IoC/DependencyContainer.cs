using System;
using System.Collections.Generic;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ReenWise.Application.Interfaces;
using ReenWise.Application.Services;
using ReenWise.Infrastructure.Data.Context;
using ReenWise.Domain.Interfaces;
using ReenWise.Infrastructure.Data.Repositories;
using ReenWise.Domain.Commands;
using ReenWise.Domain.CommandHandler;
using ReenWise.Domain.Dtos;
using ReenWise.Domain.Models;
using ReenWise.Domain.Models.Mirror;
using ReenWise.Domain.Queries;
using System.Threading.Tasks;

namespace ReenWise.Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain InMemory MediatR

            // Domain Handlers
            //services.AddScoped<IRequestHandler<CreateEquipmentCommand, bool>, EquipmentDto>();
            services.AddScoped<IRequestHandler<CreateEquipmentCommand, Equipment>, CreateEquipmentHandler>();
            services.AddScoped<IRequestHandler<CreateVehicleCommand, Vehicle>, CreateVehicleHandler>();
            services.AddScoped<IRequestHandler<GetAllEquipmentQuery, List<Equipment>>, GetAllEquipmentHandler>();
            services.AddScoped<IRequestHandler<GetAllVehicleQuery, List<Vehicle>>, GetAllVehicleHandler>();
            services.AddScoped<IRequestHandler<GetEquipmentByIdQuery, Equipment>, GetEquipmentByIdHandler > ();
            services.AddScoped<IRequestHandler<GetVehicleByIdQuery, Vehicle>, GetVehicleByIdHandler>();
            services.AddScoped<IRequestHandler<UpdateEquipmentCommand, bool>, UpdateEquipmentHandler>();
            services.AddScoped<IRequestHandler<UpdateVehicleCommand, bool>, UpdateVehicleHandler>();
            services.AddScoped<IRequestHandler<DeleteEquipmentCommand, bool>, DeleteEquipmentHandler>();
            services.AddScoped<IRequestHandler<DeleteVehicleCommand, bool>, DeleteVehicleHandler>();

            // Application layer
            services.AddScoped<IEquipmentService, EquipmentService>();
            services.AddScoped<IVehicleService, VehicleService>();

            // Infrastructure.Data layer
            //services.AddScoped<IEquipmentRepository, EquipmentRepository>();
            services.AddScoped<IRepository<Equipment>, EquipmentRepository>();
            //services.AddScoped<IRepository<Equipment>, Repository<Equipment>>();
            services.AddScoped<IRepository<Vehicle>, Repository<Vehicle>>();
            services.AddScoped<ReenWiseDbContext>();
        }
    }
}
