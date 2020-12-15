using Project.Model;
using System;
using System.Threading.Tasks;

namespace Project.Repository.Common
{
    public interface IVehicleUnitOfWork : IDisposable
    {
        Task<VehicleModel> CreateVehicleModel(VehicleModel modelToCreate);
    }
}
