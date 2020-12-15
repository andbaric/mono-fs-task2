using AutoMapper;
using Project.DAL;
using Project.DAL.Entities;
using Project.Model;
using Project.Repository.Common;
using Project.Repository.Common.Generic;
using Project.Repository.Generic;
using System;
using System.Collections.Generic;
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

        public async Task<VehicleMake> CreateMake(VehicleMake makeToCreate)
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

        public async Task<IEnumerable<VehicleMake>> ReadMakes()
        {
            var makesToReadEntities = await GetAll();
            var makes = mapper.Map<List<VehicleMake>>(makesToReadEntities);

            return makes;
        }

        public async Task<VehicleMake> UpdateMake(VehicleMake makeUpdates)
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
