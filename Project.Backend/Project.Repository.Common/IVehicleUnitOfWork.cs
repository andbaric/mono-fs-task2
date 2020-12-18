using Project.Model.Common.VehicleModelResource;
using Project.Model.VehicleMakeResource;
using Project.Model.VehicleModelResource;
using System;
using System.Threading.Tasks;

namespace Project.Repository.Common
{
    public interface IVehicleUnitOfWork : IDisposable
    {
        Task<VehicleModel> CreateVehicleModel(IVehicleModel<VehicleMake> modelToCreate);
    }
}
