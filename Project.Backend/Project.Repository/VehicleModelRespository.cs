using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project.DAL;
using Project.DAL.Entities;
using Project.Model;
using Project.Repository.Common;
using Project.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Repository
{
    public class VehicleModelRespository : Repository<VehicleModelEntity>, IVehicleModelRespository
    {
        private readonly IMapper mapper;

        public VehicleModelRespository(VehicleDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            this.mapper = mapper;
        }

        public async Task<VehicleModel> ReadModelById(Guid id)
        {
            try
            {
                var modelToRead = await(
                    from model in dbSet.Where(model => model.Id == id)
                    join make in dbContext.Set<VehicleMakeEntity>() on model.MakeId equals make.Id
                    select new VehicleModel
                    {
                        Id = model.Id,
                        Name = model.Name,
                        Abrv = model.Abrv,
                        Make = new VehicleMake
                        {
                            Id = make.Id,
                            Name = make.Name,
                            Abrv = make.Abrv
                        }
                    }).SingleOrDefaultAsync();

                return modelToRead;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<VehicleModel> UpdateModel(VehicleModel modelUpdates)
        {
            var modelEntityUpdates = mapper.Map<VehicleModelEntity>(modelUpdates);
            var modelToUpdateEntity = await Update(modelEntityUpdates);
            await SaveAsync();
            var updatedModel = await ReadModelById(modelToUpdateEntity.Id);

            return updatedModel;
        }

        public async Task<IEnumerable<VehicleModel>> ReadModels()
        {
            var modelsToRead = await(
                from model in dbSet
                join make in dbContext.Set<VehicleMakeEntity>() on model.MakeId equals make.Id
                select new VehicleModel
                {
                    Id = model.Id,
                    Name = model.Name,
                    Abrv = model.Abrv,
                    Make = new VehicleMake
                    {
                        Id = make.Id,
                        Name = make.Name,
                        Abrv = make.Abrv
                    }
                }).ToListAsync();

            return modelsToRead;
        }

        public async Task<VehicleModel> DeleteModelById(Guid id)
        { 
            var deletedModel = await ReadModelById(id);
            await DeleteById(id);
            await SaveAsync();

            return deletedModel;
        }
    }
}
