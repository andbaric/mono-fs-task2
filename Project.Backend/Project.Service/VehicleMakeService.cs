using Project.Common.Paging;
using Project.Model.Common.VehicleMakeResource;
using Project.Model.Common.VehicleMakeResource.Params;
using Project.Model.VehicleMakeResource;
using Project.Repository.Common;
using Project.Service.Common;
using System;
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

        public async Task<IVehicleMake> CreateVehicleMake(IVehicleMake makeToCreate)
        {
            return await repository.CreateMake(makeToCreate);
        }

        public async Task<IPagedList<VehicleMake>> ReadVehicleMakes(IReadVehicleMakesParams readParams)
        {
            return await repository.ReadVehicleMakes(readParams);
        }
        public async Task<IVehicleMake> ReadVehicleMake(Guid id)
        {
            return await repository.ReadMakeById(id);
        }

        public async Task<IVehicleMake> UpdateVehicleMake(IVehicleMake updatedMake)
        {
            return await repository.UpdateMake(updatedMake);
        }

        public async Task<IVehicleMake> DeleteVehicleMake(Guid id)
        {
            return await repository.DeleteMakeById(id);
        }
    }
}
