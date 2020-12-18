using Project.Common.Paging;
using Project.DAL.Entities;
using Project.Model.Common.VehicleModelResource;
using Project.Model.Common.VehicleModelResource.Params;
using Project.Model.VehicleMakeResource;
using Project.Model.VehicleModelResource;
using Project.Repository.Common.Generic;
using System;
using System.Threading.Tasks;

namespace Project.Repository.Common
{
    public interface IVehicleModelRespository : IRepository<VehicleModelEntity>
    {
        Task<VehicleModel> ReadModelById(Guid id);
        Task<PagedList<VehicleModel>> ReadVehicleModels(IReadVehicleModelsParams readParams);
        Task<VehicleModel> UpdateModel(IVehicleModel<VehicleMake> modelUpdates);
        Task<VehicleModel> DeleteModelById(Guid id);
    }
}
