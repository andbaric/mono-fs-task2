using Project.Model.Common.DTOs.VehicleModel;
using Project.Model.Common.DTOs.VehicleModel.ReadVehicleModels;
using System.Threading.Tasks;

namespace Project.Service.Common
{
    public interface IVehicleModelService
    {
        Task<ICreateVehicleModelResponse> CreateVehicleModel(ICreateVehicleModelRequest request);
        Task<IReadVehicleModelResponse> ReadVehicleModel(IReadVehicleModelRequest request);
        Task<IReadVehicleModelsResponse> ReadVehicleModels(IReadVehicleModelsRequest request);
        Task<IUpdateVehicleModelResponse> UpdateVehicleModel(IUpdateVehicleModelRequest request);
        Task<IDeleteVehicleModelResponse> DeleteVehicleModel(IDeleteVehicleModelRequest request);
    }
}
