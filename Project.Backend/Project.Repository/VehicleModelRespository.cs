using Microsoft.EntityFrameworkCore;
using Project.DAL;
using Project.DAL.Entities;
using Project.Model.DTOs.VehicleModel.ReadVehicleModels;
using Project.Repository.Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Model.Common.DTOs.VehicleModel.ReadVehicleModels;
using System;
using Project.Model.DTOs.VehicleModel;
using Project.Model.Common.DTOs.VehicleModel;

namespace Project.Repository
{
    public class VehicleModelRespository : Repository<VehicleModelEntity>, IVehicleModelRespository
    {
        public VehicleModelRespository(VehicleDbContext context) : base(context)
        {
        }

        new public async Task<IEnumerable<ReadVehicleModelsResponseItem>> GetAll()
        {
            var modelCollection = await (
                from model in dbSet
                join make in dbContext.Set<VehicleMakeEntity>() on model.MakeId equals make.Id
                select new ReadVehicleModelsResponseItem
                {
                    Id = model.Id,
                    Name = model.Name,
                    Abrv = model.Abrv,
                    Make = new Model.DTOs.VehicleModel.ReadVehicleModels.VehicleMake() { Id = make.Id, Name = make.Name }
                }).ToListAsync();

            return modelCollection;
        }

        new public async Task<ReadVehicleModelResponse> GetById(Guid id)
        {
            try
            {
                var modelToRead= await(
                    from model in dbSet.Where(model => model.Id == id)
                    join make in dbContext.Set<VehicleMakeEntity>() on model.MakeId equals make.Id
                    select new ReadVehicleModelResponse 
                    { 
                        Id = model.Id, 
                        Name = model.Name, 
                        Abrv = model.Abrv,
                        Make = new Model.DTOs.VehicleModel.VehicleMake() { Id = make.Id, Name = make.Name }
                    })
                    .SingleOrDefaultAsync();

                return modelToRead;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
