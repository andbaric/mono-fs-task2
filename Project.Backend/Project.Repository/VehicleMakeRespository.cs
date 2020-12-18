using AutoMapper;
using Project.Common.Paging;
using Project.DAL;
using Project.DAL.Entities;
using Project.Model.Common.VehicleMakeResource;
using Project.Model.Common.VehicleMakeResource.Params;
using Project.Model.VehicleMakeResource;
using Project.Repository.Common;
using Project.Repository.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Repository
{
    public class VehicleMakeRespository : Repository<VehicleMakeEntity>, IVehicleMakeRespository
    {
        private readonly IMapper mapper;

        public VehicleMakeRespository(VehicleDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            this.mapper = mapper;
        }

        public async Task<VehicleMake> CreateMake(IVehicleMake makeToCreate)
        {
            var newMakeToCreateEntity = mapper.Map<VehicleMakeEntity>(makeToCreate);
            var makeToCreateEntity = await Create(newMakeToCreateEntity);
            await SaveAsync();
            var createdMake = mapper.Map<VehicleMake>(makeToCreateEntity);

            return createdMake;
        }
        public async Task<VehicleMake> ReadMakeById(Guid id)
        {
            var makeToReadEntity = await GetById(id);
            var make = mapper.Map<VehicleMake>(makeToReadEntity);

            return make;
        }

        public async Task<PagedList<VehicleMake>> ReadVehicleMakes(IReadVehicleMakesParams readParams)
        {
            var vehicleMakesEntitiesQuery = dbSet.AsQueryable();

            var nameFilter = !string.IsNullOrWhiteSpace(readParams.Name) ? readParams.Name.Trim() : null; 
            var abrvFilter = !string.IsNullOrWhiteSpace(readParams.Abrv) ? readParams.Abrv.Trim() : null;
            if (nameFilter != null) vehicleMakesEntitiesQuery = 
                    vehicleMakesEntitiesQuery.Where(n => n.Name == nameFilter);
            if (abrvFilter != null) vehicleMakesEntitiesQuery = 
                    vehicleMakesEntitiesQuery.Where(n => n.Abrv == abrvFilter);

            var orderBy = !string.IsNullOrWhiteSpace(readParams.OrderBy) ? readParams.OrderBy.Trim().ToLowerInvariant() : null;
            if (orderBy != null)
            {
                vehicleMakesEntitiesQuery = orderBy switch
                {
                    string value when value == "name" || value == "name_desc" => value == "name_desc" ?
                                               vehicleMakesEntitiesQuery.OrderByDescending(s => s.Name)
                                               : vehicleMakesEntitiesQuery.OrderBy(s => s.Name),
                    string value when value == "abrv" || value == "abrv_desc" => value == "abrv_desc" ?
                                                vehicleMakesEntitiesQuery.OrderByDescending(s => s.Abrv)
                                                : vehicleMakesEntitiesQuery.OrderBy(s => s.Abrv),
                    _ => vehicleMakesEntitiesQuery.OrderBy(s => s.Name),
                };
            } 
            
            var pagedVehicleMakesEntities = await PagedList<VehicleMakeEntity>
                .CreateAsync(vehicleMakesEntitiesQuery, readParams.PageSize, readParams.PageNumber);
            var pagedVehicleMakes = pagedVehicleMakesEntities.ToMappedPagedList<VehicleMakeEntity, VehicleMake>(mapper);

            return pagedVehicleMakes;
        }

        public async Task<VehicleMake> UpdateMake(IVehicleMake makeUpdates)
        {
            var makeEntityUpdates = mapper.Map<VehicleMakeEntity>(makeUpdates);
            var makeToUpdateEntity = await Update(makeEntityUpdates);
            await SaveAsync();
            var updatedMake = mapper.Map<VehicleMake>(makeToUpdateEntity);

            return updatedMake;
        }
        public async Task<VehicleMake> DeleteMakeById(Guid id)
        {
            var makeToDeleteEntity = await DeleteById(id);
            await SaveAsync();
            var deletedMake = mapper.Map<VehicleMake>(makeToDeleteEntity);

            return deletedMake;
        }
    }
}
