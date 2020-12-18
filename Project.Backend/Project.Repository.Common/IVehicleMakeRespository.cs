using Project.Common.Paging;
using Project.DAL.Entities;
using Project.Model.Common.VehicleMakeResource;
using Project.Model.Common.VehicleMakeResource.Params;
using Project.Model.VehicleMakeResource;
using Project.Repository.Common.Generic;
using System;
using System.Threading.Tasks;

namespace Project.Repository.Common
{
    public interface IVehicleMakeRespository : IRepository<VehicleMakeEntity>
    {
        Task<VehicleMake> CreateMake(IVehicleMake makeToCreate);
        Task<VehicleMake> ReadMakeById(Guid id);
        Task<PagedList<VehicleMake>> ReadVehicleMakes(IReadVehicleMakesParams readParams);
        Task<VehicleMake> UpdateMake(IVehicleMake makeUpdates);
        Task<VehicleMake> DeleteMakeById(Guid id);
    }
}
