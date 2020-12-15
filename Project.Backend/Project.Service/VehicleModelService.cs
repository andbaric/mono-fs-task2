using Project.Model;
using Project.Repository.Common;
using Project.Repository.Common.Generic;
using Project.Service.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Service
{
    public class VehicleModelService : IVehicleModelService
    {
        public readonly IVehicleUnitOfWork unitOfWork;
        public readonly IVehicleModelRespository repository;

        public VehicleModelService(IVehicleModelRespository repository, IVehicleUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<VehicleModel> CreateVehicleModel(VehicleModel modelToCreate)
        {
            return await unitOfWork.CreateVehicleModel(modelToCreate);
        }

        public async Task<VehicleModel> ReadVehicleModel(Guid id)
        {
            return await repository.ReadModelById(id);
        }

        public async Task<IEnumerable<VehicleModel>> ReadVehicleModels()
        {
            return await repository.ReadModels();
        }

        public async Task<VehicleModel> UpdateVehicleModel(VehicleModel modelUpdates)
        {
            return await repository.UpdateModel(modelUpdates);
        }

        public async Task<VehicleModel> DeleteVehicleModel(Guid id)
        {
            return await repository.DeleteModelById(id);
        }
    }
}
