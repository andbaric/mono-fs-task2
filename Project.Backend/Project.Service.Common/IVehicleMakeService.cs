using Project.Common.Paging;
using Project.Model.Common.VehicleMakeResource;
using Project.Model.Common.VehicleMakeResource.Params;
using Project.Model.VehicleMakeResource;
using System;
using System.Threading.Tasks;

namespace Project.Service.Common
{
    public interface IVehicleMakeService
    {
        Task<IVehicleMake> CreateVehicleMake(IVehicleMake makeToCreate);
        Task<IPagedList<VehicleMake>> ReadVehicleMakes(IReadVehicleMakesParams readParams);
        Task<IVehicleMake> ReadVehicleMake(Guid id);
        Task<IVehicleMake> UpdateVehicleMake(IVehicleMake makeUpdates);
        Task<IVehicleMake> DeleteVehicleMake(Guid id);
    }
}
