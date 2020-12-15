using Project.Model;
using Project.Model;
using Project.Repository.Common;
using Project.Service.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Service
{
    public class VehicleMakeService : IVehicleMakeService
    {
        private readonly IVehicleMakeRespository repository;

        public VehicleMakeService(IVehicleMakeRespository repository)
        {
            this.repository = repository;
        }

        public async Task<VehicleMake> CreateVehicleMake(VehicleMake makeToCreate)
        {
            return await repository.CreateMake(makeToCreate);
        }

        public async Task<IEnumerable<VehicleMake>> ReadVehicleMakes()
        {
           return await repository.ReadMakes();
        }

        public async Task<VehicleMake> ReadVehicleMake(Guid id)
        {
            return await repository.ReadMakeById(id);
        }

        public async Task<VehicleMake> UpdateVehicleMake(VehicleMake updatedMake)
        {
            return await repository.UpdateMake(updatedMake);
        }

        public async Task<VehicleMake> DeleteVehicleMake(Guid id)
        {
            return await repository.DeleteMakeById(id);
        }
    }
}
