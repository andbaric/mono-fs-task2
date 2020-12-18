using Project.Common.Paging;
using Project.Model.Common.VehicleModelResource;
using Project.Model.Common.VehicleModelResource.Params;
using Project.Model.VehicleMakeResource;
using Project.Model.VehicleModelResource;
using System;
using System.Threading.Tasks;

namespace Project.Service.Common
{
    public interface IVehicleModelService
    {
        Task<IVehicleModel<VehicleMake>> CreateVehicleModel(IVehicleModel<VehicleMake> modelToCreate);
        Task<IVehicleModel<VehicleMake>> ReadVehicleModel(Guid id);
        Task<IPagedList<VehicleModel>> ReadVehicleModels(IReadVehicleModelsParams readParams);
        Task<IVehicleModel<VehicleMake>> UpdateVehicleModel(IVehicleModel<VehicleMake> modelUpdates);
        Task<IVehicleModel<VehicleMake>> DeleteVehicleModel(Guid id);
    }
}
