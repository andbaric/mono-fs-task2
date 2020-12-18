using Project.Common.Paging;
using Project.Model.Common.VehicleMakeResource;
using Project.Model.Common.VehicleModelResource;
using Project.Model.Common.VehicleModelResource.Params;
using Project.Model.VehicleMakeResource;
using Project.Model.VehicleModelResource;
using Project.Repository.Common;
using Project.Service.Common;
using System;
using System.Threading.Tasks;

namespace Project.Service
{
    public class VehicleModelService : IVehicleModelService
    {
        public readonly IVehicleUnitOfWork unitOfWork;
        public readonly IVehicleModelRespository repository;

        public VehicleModelService(IVehicleUnitOfWork unitOfWork, IVehicleModelRespository repository)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
        }

        public async Task<IVehicleModel<VehicleMake>> CreateVehicleModel(IVehicleModel<VehicleMake> modelToCreate)
        {
            return await unitOfWork.CreateVehicleModel(modelToCreate);
        }

        public async Task<IVehicleModel<VehicleMake>> ReadVehicleModel(Guid id)
        {
            return await repository.ReadModelById(id);
        }

        public async Task<IPagedList<VehicleModel>> ReadVehicleModels(IReadVehicleModelsParams readParams)
        {
            return await repository.ReadVehicleModels(readParams);
        }

        public async Task<IVehicleModel<VehicleMake>> UpdateVehicleModel(IVehicleModel<VehicleMake> modelUpdates)
        {
            return await repository.UpdateModel(modelUpdates);
        }

        public async Task<IVehicleModel<VehicleMake>> DeleteVehicleModel(Guid id)
        {
            return await repository.DeleteModelById(id);
        }
    }
}
