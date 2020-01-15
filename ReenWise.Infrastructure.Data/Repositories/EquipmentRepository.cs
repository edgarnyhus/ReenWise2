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

        public async Task<IEnumerable<Equipment>> GetAll()
        {
            _logger.LogInformation($"GetAll: Get all equipment");

            var query = _dbContext.Set<Equipment>()
                .Include(_dbContext.GetIncludePaths(typeof(Equipment)))
                .Include(x => x.Locations);
            var result = await query.ToListAsync();
            return result as IEnumerable<Equipment>;

        }


        public async Task<Equipment> Create(Equipment entity)
        {
            CheckProperties(entity);
            var result = await base.Create(entity);

            return entity;
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

            var _entity = GetById(id);
            if (_entity == null)
            {
                return await Create(entity) != null;
            }

            CheckProperties(entity);
            return await base.Update(id, entity);
            var result = _dbContext.Equipment.Update(entity);
            //_dbContext.Entry<T>(_entity).State = EntityState.Detached;
            await _dbContext.SaveChangesAsync();
            return result != null ? true : false;
        }

        private void CheckProperties(Equipment entity)
        {
            if (entity.Model != null)
            {
                entity.ModelId = entity.Model.Id;
                if (entity.ModelId == Guid.Empty)
                {
                    var _result = GetOrCreateModel(entity.Model);
                    entity.ModelId = _result.Result.Id;
                }
            }
            if (entity.OperatingHours != null)
            {
                entity.OperatingHoursId = entity.OperatingHours.Id;
                if (entity.OperatingHoursId == Guid.Empty)
                {
                    var _result = GetOrCreateOperatingHours(entity.OperatingHours);
                    entity.OperatingHoursId = _result.Result.Id;
                }
            }
            if (entity.InitialOperatingHours != null)
            {
                entity.InitialOperatingHoursId = entity.InitialOperatingHours.Id;
                if (entity.InitialOperatingHoursId == Guid.Empty)
                {
                    var _result = GetOrCreateOperatingHours(entity.OperatingHours);
                    entity.InitialOperatingHoursId = _result.Result.Id;
                }
            }
            if (entity.Unit != null)
            {
                entity.UnitId = entity.Unit.Id;
                if (entity.UnitId == Guid.Empty)
                {
                    var _result = GetOrCreateUnit(entity.Unit);
                    entity.UnitId = _result.Result.Id;
                }
            }
            if (entity.Organization != null)
            {
                entity.OrganizationId = entity.Organization.Id;
                if (entity.OrganizationId == Guid.Empty)
                {
                    var _result = GetOrCreateOrganization(entity.Organization);
                    entity.OrganizationId = _result.Result.Id;
                }
            }
        }

        public async Task<Organization> GetOrCreateOrganization(Organization organization)
        {
            var entity = await _dbContext.Organizations.FirstOrDefaultAsync(x =>
                x.Id == organization.Id ||
                String.Compare(x.Name, organization.Name) == 0);
            if (entity == null)
            {
                var result = await _dbContext.Organizations.AddAsync(organization);
                entity = result.Entity;
            }
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Model> GetOrCreateModel(Model model)
        {
            var entity = await _dbContext.Models
                .FirstOrDefaultAsync(x =>
                    x.Id == model.Id || String.Compare(x.Name, model.Name) == 0);
            if (entity == null)
            {
                var result = await _dbContext.Models.AddAsync(model);
                entity = result.Entity;
            }
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Unit> GetOrCreateUnit(Unit unit)
        {
            var entity = await _dbContext.Units
                .FirstOrDefaultAsync(x =>
                    x.Id == unit.Id || String.Compare(x.SerialNumber, unit.SerialNumber) == 0);
            if (entity == null)
            {
                var result = await _dbContext.Units.AddAsync(unit);
                entity = result.Entity;
            }
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async ValueTask<OperatingHours> GetOrCreateOperatingHours(OperatingHours operatingHours)
        {
            var entity = await _dbContext.OperatingHours
                .FirstOrDefaultAsync(x =>
                    x.Id == operatingHours.Id ||
                    x.Hours == operatingHours.Hours && x.UnitDriven == operatingHours.UnitDriven);
            if (entity == null)
            {
                var result = await _dbContext.OperatingHours.AddAsync(operatingHours);
                entity = result.Entity;
            }
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Location> GetOrCreateLocation(Location location)
        {
            var entity = await _dbContext.Locations
                .FirstOrDefaultAsync(x =>
                    x.Id == location.Id ||
                    DateTime.Compare(x.Timestamp, location.Timestamp) == 0);
                         //&& (x.inMovement == location.inMovement)
                         //&& (x.latitude == location.latitude)
                         //&& (x.latitude == location.longitude));
                         //&& (Math.Abs(x.latitude - location.latitude) < 0.001)
                         //&& (Math.Abs(x.latitude - location.longitude) < 0.001));
            if (entity == null)
            {
                var result = await _dbContext.Locations.AddAsync(location);
                entity = result.Entity;
            }
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Temperature> GetOrCreateTemperature(Temperature temperature)
        {
            var entity = await _dbContext.Temperatures
                .FirstOrDefaultAsync(x =>
                    x.Id == temperature.Id ||
                    DateTime.Compare(x.Timestamp, temperature.Timestamp) == 0);
            if (entity == null)
            {
                var result = await _dbContext.Temperatures.AddAsync(temperature);
                entity = result.Entity;
            }
            await _dbContext.SaveChangesAsync();
            return entity;
        }



    }
}
