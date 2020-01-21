using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ReenWise.Domain.CommandHandler;
using ReenWise.Domain.Interfaces;
using ReenWise.Domain.Models.Mirror;
using ReenWise.Domain.Specifications;
using ReenWise.Infrastructure.Data.Context;

namespace ReenWise.Infrastructure.Data.Repositories
{
    public class EquipmentRepository : Repository<Equipment>, IEquipmentRepository
    {
        private readonly ILogger<EquipmentRepository> _logger;

        public EquipmentRepository(ReenWiseDbContext dbContext, ILogger<EquipmentRepository> logger) : base(dbContext)
        {
            _logger = logger;
        }

        public async Task<Equipment> Add(Equipment entity)
        {
            Equipment _entity;

            _entity = _dbContext.Equipment.Add(entity).Entity;
            CheckProperties(_entity);

            _dbContext.Entry(_entity.Model).State = EntityState.Modified;
            _dbContext.Entry(_entity.OperatingHours).State = EntityState.Modified;
            _dbContext.Entry(_entity.Unit).State = EntityState.Modified;
            _dbContext.Entry(_entity.Organization).State = EntityState.Modified;
            _dbContext.Entry(_entity.InitialOperatingHours).State = EntityState.Modified;
            _dbContext.Entry(_entity).State = EntityState.Added;
           //_entity.Model = null;
            //_entity.OperatingHours = null;
            //_entity.Unit = null;
            //_entity.Organization = null;
            //_entity.InitialOperatingHours = null;

            _dbContext.SaveChanges();
            return _entity;
        }

        public async Task<bool> Update(Guid id, Equipment entity)
        {
            // Update entity
            // 1. Create instance for DbContext class
            // 2. Retrieve entity by key
            // 3. Make changes on entity's properties
            // 4. Save changes
            //using (var context = new StoreDbContext())
            //{
            //    // Retrieve entity by id
            //    // Answer for question #1
            //    var entity = context.Products.FirstOrDefault(item => item.ProductID == id);

            //    // Validate entity is not null
            //    if (entity != null)
            //    {
            //        // Answer for question #2

            //        // Make changes on entity
            //        entity.UnitPrice = 49.99m;
            //        entity.Description = "Collector's edition";

            //        // Update entity in DbSet
            //        context.Products.Update(entity);

            //        // Save changes in database
            //        context.SaveChanges();
            //    }
            //}

            if (id == Guid.Empty)
                return false;

            var _entity = FindById(id);
            if (_entity == null)
            {
                return await Add(entity) != null;
            }

            CheckProperties(entity);
            return await base.Update(id, entity);
            var result = _dbContext.Equipment.Update(entity);
            await _dbContext.SaveChangesAsync();
            return result != null ? true : false;
        }

        private void CheckProperties(Equipment entity)
        {
            if (entity.Model != null)
            {
                if (entity.Model.Id == Guid.Empty)
                {
                    entity.Model = GetOrCreateModel(entity.Model).Result;
                    entity.ModelId = entity.Model.Id;
                }
            }
            if (entity.OperatingHours != null)
            {
                if (entity.OperatingHoursId == Guid.Empty)
                {
                    entity.OperatingHours = GetOrCreateOperatingHours(entity.OperatingHours).Result;
                    entity.OperatingHoursId = entity.OperatingHours.Id;
                }
            }
            if (entity.InitialOperatingHours != null)
            {
                if (entity.InitialOperatingHoursId == Guid.Empty)
                {
                    entity.InitialOperatingHours = GetOrCreateOperatingHours(entity.OperatingHours).Result;
                    entity.InitialOperatingHoursId = entity.InitialOperatingHours.Id;
                }
            }
            if (entity.Unit != null)
            {
                if (entity.UnitId == Guid.Empty)
                {
                    entity.Unit = GetOrCreateUnit(entity.Unit).Result;
                    entity.UnitId = entity.Unit.Id;
                }
            }
            if (entity.Organization != null)
            {
                if (entity.OrganizationId == Guid.Empty)
                {
                    entity.Organization = GetOrCreateOrganization(entity.Organization).Result;
                    entity.OrganizationId = entity.Organization.Id;
                }
            }
        }

        public async Task<Organization> GetOrCreateOrganization(Organization organization)
        {
            var _organization = _dbContext.Organizations.SingleOrDefault(x =>
                x.Id == organization.Id || String.Compare(x.Name, organization.Name) == 0);
            if (_organization == null)
            {
                var result = _dbContext.Organizations.Add(organization);
                await _dbContext.SaveChangesAsync();
                _organization = result.Entity;
            }
            return _organization;
        }

        public async Task<Model> GetOrCreateModel(Model model)
        {
            var _model = _dbContext.Models.SingleOrDefault(x =>
                    x.Id == model.Id || String.Compare(x.Name, model.Name) == 0);
            if (_model == null)
            {
                var result = _dbContext.Models.Add(model);
                await _dbContext.SaveChangesAsync();
                _model = result.Entity;
            }
            return _model;
        }

        public async Task<Unit> GetOrCreateUnit(Unit unit)
        {
            var _unit = _dbContext.Units.SingleOrDefault(x =>
                    x.Id == unit.Id || String.Compare(x.SerialNumber, unit.SerialNumber) == 0);
            if (_unit == null)
            {
                var result = _dbContext.Units.Add(unit);
                await _dbContext.SaveChangesAsync();
                _unit = result.Entity;
            }
            return _unit;
        }

        public async ValueTask<OperatingHours> GetOrCreateOperatingHours(OperatingHours operatingHours)
        {
            var _operatingHours = _dbContext.OperatingHours.SingleOrDefault(x =>
                    x.Id == operatingHours.Id ||
                    x.Hours == operatingHours.Hours && x.UnitDriven == operatingHours.UnitDriven);
            if (_operatingHours == null)
            {
                var result = _dbContext.OperatingHours.Add(operatingHours);
                await _dbContext.SaveChangesAsync();
                _operatingHours = result.Entity;
            }
            return _operatingHours;
        }

        public async Task<Location> GetOrCreateLocation(Location location)
        {
            var _location = _dbContext.Locations.SingleOrDefault(x =>
                    x.Id == location.Id || DateTime.Compare(x.Timestamp, location.Timestamp) == 0);
            if (_location == null)
            {
                var result = _dbContext.Locations.Add(location);
                await _dbContext.SaveChangesAsync();
                _location = result.Entity;
            }
            return _location;
        }

        public async Task<Temperature> GetOrCreateTemperature(Temperature temperature)
        {
            var _temperature = _dbContext.Temperatures.SingleOrDefault(x =>
                    x.Id == temperature.Id ||
                    DateTime.Compare(x.Timestamp, temperature.Timestamp) == 0);
            if (_temperature == null)
            {
                var result = _dbContext.Temperatures.Add(temperature);
                await _dbContext.SaveChangesAsync();
                _temperature = result.Entity;
            }
            return _temperature;
        }
    }
}
