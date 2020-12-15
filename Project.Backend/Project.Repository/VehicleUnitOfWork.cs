using AutoMapper;
using Project.DAL;
using Project.DAL.Entities;
using Project.Model;
using Project.Repository.Common;
using System.Threading.Tasks;

namespace Project.Repository
{
    public class VehicleUnitOfWork : UnitOfWork<VehicleDbContext>, IVehicleUnitOfWork
    {
        private readonly IMapper mapper;

        private IVehicleMakeRespository vehicleMakeRespository;
        private IVehicleModelRespository vehicleModelRespository;

        public VehicleUnitOfWork(VehicleDbContext DbContext,
            IVehicleMakeRespository vehicleMakeRespository, 
            IVehicleModelRespository vehicleModelRespository,
            IMapper mapper) : base(DbContext)
        {
            this.vehicleMakeRespository = vehicleMakeRespository;
            this.vehicleModelRespository = vehicleModelRespository;
            this.mapper = mapper;
        }
        public async Task<VehicleModel> CreateVehicleModel(VehicleModel modelToCreate)
        {
            var modelExists = await vehicleModelRespository.ReadModelById(modelToCreate.Id) != null;
            if (modelExists) return null;

            var makeEntity = await vehicleMakeRespository.GetById(modelToCreate.Make.Id);
            var newMakeEntityValues = mapper.Map<VehicleMakeEntity>(modelToCreate.Make);
            if (makeEntity != null) await UpdateAsync(newMakeEntityValues);
            else await AddAsync(newMakeEntityValues);

            modelToCreate.Make.Id = newMakeEntityValues.Id;
            var modelEntityToCreate = mapper.Map<VehicleModelEntity>(modelToCreate);
            await AddAsync(modelEntityToCreate);
            await CommitAsync();
            var createdModel = await vehicleModelRespository.ReadModelById(modelEntityToCreate.Id);

            return createdModel;
        }
    }
}
