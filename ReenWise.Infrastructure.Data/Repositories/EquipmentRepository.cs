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
            await CheckProperties(entity);
            //entity = _dbContext.Equipment.Add(entity).Entity;
            entity = _dbContext.Equipment.Attach(entity).Entity;
            _dbContext.Entry(entity).State = EntityState.Added;
            _dbContext.SaveChanges();

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

            var _entity = FindById(id);
            if (_entity == null)
            {
                return await Add(entity) != null;
            }

            await CheckProperties(entity);
            //var result = _dbContext.Equipment.Update(entity);
            entity = _dbContext.Equipment.Attach(entity).Entity;
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return true;
        }

        private async Task CheckProperties(Equipment entity)
        {
            if (entity.Model != null)
            {
                var _model = _dbContext.Models.FirstOrDefault(x =>
                    x.Id == entity.Model.Id || x.Name.Equals(entity.Model.Name));
                if (_model != null)
                {
                    entity.ModelId = _model.Id;
                    //_dbContext.Entry(entity.Model).State = EntityState.Unchanged; // Modified;
                    entity.Model = null;
                }
            }
            if (entity.OperatingHours != null)
            {
                var _operatingHours = await _dbContext.OperatingHours.FirstOrDefaultAsync(x =>
                    x.Id == entity.OperatingHours.Id ||
                    (x.Hours == entity.OperatingHours.Hours && x.UnitDriven == entity.OperatingHours.UnitDriven));
                if (_operatingHours != null)
                {
                    entity.OperatingHoursId = _operatingHours.Id;
                    //_dbContext.Entry(entity.OperatingHours).State = EntityState.Unchanged; //Modified;
                    entity.OperatingHours = null;
                }
            }
            if (entity.InitialOperatingHours != null)
            {
                var _operatingHours = await _dbContext.OperatingHours.FirstOrDefaultAsync(x =>
                    x.Id == entity.InitialOperatingHours.Id ||
                    (x.Hours == entity.InitialOperatingHours.Hours && x.UnitDriven == entity.InitialOperatingHours.UnitDriven));
                if (_operatingHours != null)
                {
                    entity.InitialOperatingHoursId = _operatingHours.Id;
                    //_dbContext.Entry(entity.InitialOperatingHours).State = EntityState.Unchanged; //Modified;
                    entity.InitialOperatingHours = null;
                }
            }
            if (entity.Unit != null)
            {
                var _unit = await _dbContext.Units.FirstOrDefaultAsync(x =>
                    x.Id == entity.Unit.Id || x.SerialNumber.Equals(entity.Unit.SerialNumber));
                if (_unit != null)
                {
                    entity.UnitId = _unit.Id;
                    //_dbContext.Entry(entity.Unit).State = EntityState.Unchanged; //Modified;
                    entity.Unit = null;
                }
            }
            if (entity.Organization != null)
            {
                var _organization = await _dbContext.Organizations.FirstOrDefaultAsync(x =>
                    x.Id == entity.Organization.Id || x.Name.Equals(entity.Organization.Name));
                if (_organization != null)
                {
                    entity.OrganizationId = _organization.Id;
                    //_dbContext.Entry(entity.Organization).State = EntityState.Unchanged; //Modified;
                    entity.Organization = null;
                }
            }
        }
    }
}
