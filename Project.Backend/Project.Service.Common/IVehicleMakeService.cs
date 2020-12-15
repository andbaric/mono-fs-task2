using Project.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Service.Common
{
    public interface IVehicleMakeService
    {
        Task<VehicleMake> CreateVehicleMake(VehicleMake makeToCreate);
        Task<IEnumerable<VehicleMake>> ReadVehicleMakes();
        Task<VehicleMake> ReadVehicleMake(Guid id);
        Task<VehicleMake> UpdateVehicleMake(VehicleMake makeUpdates);
        Task<VehicleMake> DeleteVehicleMake(Guid id);
    }
}
