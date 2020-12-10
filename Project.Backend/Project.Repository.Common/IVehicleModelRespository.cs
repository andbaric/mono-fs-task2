using Project.DAL.Entities;
using Project.Model.DTOs.VehicleModel;
using Project.Model.DTOs.VehicleModel.ReadVehicleModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Repository.Common
{
    public interface IVehicleModelRespository : IRepository<VehicleModelEntity>
    {
        new Task<ReadVehicleModelResponse> GetById(Guid id);
        new Task<IEnumerable<ReadVehicleModelsResponseItem>> GetAll(); 
    }
}
