using Project.DAL.Entities;
using Project.Model;
using Project.Repository.Common.Generic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Repository.Common
{
    public interface IVehicleMakeRespository : IRepository<VehicleMakeEntity>
    {
        Task<VehicleMake> CreateMake(VehicleMake makeToCreate);
        Task<VehicleMake> ReadMakeById(Guid id);
        Task<IEnumerable<VehicleMake>> ReadMakes();
        Task<VehicleMake> UpdateMake(VehicleMake makeUpdates);
        Task<VehicleMake> DeleteMakeById(Guid id);
    }
}
