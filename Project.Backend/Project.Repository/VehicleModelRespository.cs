using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project.Common.Paging;
using Project.DAL;
using Project.DAL.Entities;
using Project.Model.Common.VehicleModelResource;
using Project.Model.Common.VehicleModelResource.Params;
using Project.Model.VehicleMakeResource;
using Project.Model.VehicleModelResource;
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
                var modelToRead = await (
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

        public async Task<VehicleModel> UpdateModel(IVehicleModel<VehicleMake> modelUpdates)
        {
            var modelEntityUpdates = mapper.Map<VehicleModelEntity>(modelUpdates);
            var modelToUpdateEntity = await Update(modelEntityUpdates);
            await SaveAsync();
            var updatedModel = await ReadModelById(modelToUpdateEntity.Id);

            return updatedModel;
        }

        public async Task<PagedList<VehicleModel>> ReadVehicleModels(IReadVehicleModelsParams readParams)
        {
            var vehicleModelsJoinQuery = dbSet
              .Join(dbContext.Set<VehicleMakeEntity>(),
                model => model.MakeId,
                make => make.Id,
                (model, make) => new VehicleModel
                {
                    Id = model.Id,
                    Name = model.Name,
                    Abrv = model.Abrv,
                    Make = new VehicleMake { Id = make.Id, Name = make.Name, Abrv = make.Abrv }
                });

            var nameFilter = !string.IsNullOrWhiteSpace(readParams.Name) ? readParams.Name.Trim() : null;
            var abrvFilter = !string.IsNullOrWhiteSpace(readParams.Abrv) ? readParams.Abrv.Trim() : null;
            var makeNameFilter = !string.IsNullOrWhiteSpace(readParams.MakeName) ? readParams.MakeName.Trim() : null;
            var makeFilter = !string.IsNullOrWhiteSpace(readParams.MakeName) ? readParams.MakeName.Trim() : null;

            if (nameFilter != null) vehicleModelsJoinQuery = 
                    vehicleModelsJoinQuery.Where(n => n.Name == nameFilter);
            if (abrvFilter != null) vehicleModelsJoinQuery =
                    vehicleModelsJoinQuery.Where(n => n.Abrv == abrvFilter);
            if (makeNameFilter != null) vehicleModelsJoinQuery =
                    vehicleModelsJoinQuery.Where(n => n.Make.Name == makeNameFilter);

            var orderBy = !string.IsNullOrWhiteSpace(readParams.OrderBy) ? readParams.OrderBy.Trim().ToLowerInvariant() : null;
            if (orderBy != null)
            {
                vehicleModelsJoinQuery = orderBy switch
                {
                    string value when value == "name" || value == "name_desc" => value == "name_desc" ?
                                               vehicleModelsJoinQuery.OrderByDescending(s => s.Name)
                                               : vehicleModelsJoinQuery.OrderBy(s => s.Name),
                    string value when value == "abrv" || value == "abrv_desc" => value == "abrv_desc" ?
                                                vehicleModelsJoinQuery.OrderByDescending(s => s.Abrv)
                                                : vehicleModelsJoinQuery.OrderBy(s => s.Abrv),
                    string value when value == "makename" || value == "makename_desc" => value == "name_desc" ?
                                                vehicleModelsJoinQuery.OrderByDescending(s => s.Make.Name)
                                                : vehicleModelsJoinQuery.OrderBy(s => s.Make.Name),
                    _ => vehicleModelsJoinQuery.OrderBy(s => s.Name),
                };
            }

            var pagedVehicleModels = await PagedList<VehicleModel>
                .CreateAsync(vehicleModelsJoinQuery, readParams.PageSize, readParams.PageNumber);

            return pagedVehicleModels;
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
