using Project.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Service.Common
{
    public interface IVehicleModelService
    {
        Task<VehicleModel> CreateVehicleModel(VehicleModel modelToCreate);
        Task<VehicleModel> ReadVehicleModel(Guid id);
        Task<IEnumerable<VehicleModel>> ReadVehicleModels();
        Task<VehicleModel> UpdateVehicleModel(VehicleModel modelUpdates);
        Task<VehicleModel> DeleteVehicleModel(Guid id);
    }
}
