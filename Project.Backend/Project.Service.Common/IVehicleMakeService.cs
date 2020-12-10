using Project.Model.Common.DTOs.VehicleMake;
using Project.Model.Common.DTOs.VehicleMake.ReadVehicleMakes;
using System;
using System.Threading.Tasks;

namespace Project.Service.Common
{
    public interface IVehicleMakeService
    {
        Task<ICreateVehicleMakeResponse> CreateVehicleMake(ICreateVehicleMakeRequest request);
        Task<IReadVehicleMakeResponse> ReadVehicleMake(IReadVehicleMakeRequest request);
        Task<IReadVehicleMakesResponse> ReadVehicleMakes(IReadVehicleMakesRequest request);
        Task<IUpdateVehicleMakeResponse> UpdateVehicleMake(IUpdateVehicleMakeRequest request);
        Task<IDeleteVehicleMakeResponse> DeleteVehicleMake(IDeleteVehicleMakeRequest request);
    }
}
