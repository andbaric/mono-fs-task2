using Project.DAL.Entities;
using Project.Model;
using Project.Repository.Common.Generic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Repository.Common
{
    public interface IVehicleModelRespository : IRepository<VehicleModelEntity>
    {
        Task<VehicleModel> ReadModelById(Guid id);
        Task<IEnumerable<VehicleModel>> ReadModels();
        Task<VehicleModel> UpdateModel(VehicleModel modelUpdates);
        Task<VehicleModel> DeleteModelById(Guid id);
    }
}
