using AutoMapper;
using Project.DAL.Entities;
using Project.Model.Common.DTOs.VehicleMake;
using Project.Model.Common.DTOs.VehicleMake.ReadVehicleMakes;
using Project.Model.DTOs.VehicleMake;
using Project.Model.DTOs.VehicleMake.ReadVehicleMakes;
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
        private readonly IMapper mapper;

        public VehicleMakeService(IVehicleMakeRespository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<ICreateVehicleMakeResponse> CreateVehicleMake(ICreateVehicleMakeRequest request)
        {
            var makeToCreateEntity = mapper.Map<VehicleMakeEntity>(request);
            await repository.Create(makeToCreateEntity);

            return null;
        }

        public async Task<IReadVehicleMakeResponse> ReadVehicleMake(IReadVehicleMakeRequest request)
        {
            var makeToReadEntity = await repository.GetById(request.Id);
            var readMakeResponse = mapper.Map<ReadVehicleMakeResponse>(makeToReadEntity);

            return readMakeResponse;
        }

        public async Task<IReadVehicleMakesResponse> ReadVehicleMakes(IReadVehicleMakesRequest request)
        {
            var makesToReadEntitieCollection = await repository.GetAll();
            var readMakesResponse = mapper.Map<ReadVehicleMakesResponse>(makesToReadEntitieCollection);

            return readMakesResponse;
        }

        public async Task<IUpdateVehicleMakeResponse> UpdateVehicleMake(IUpdateVehicleMakeRequest request)
        {
            var makeToUpdateEntity = mapper.Map<VehicleMakeEntity>(request);
            await repository.Update(makeToUpdateEntity);

            return null;
        }

        public async Task<IDeleteVehicleMakeResponse> DeleteVehicleMake(IDeleteVehicleMakeRequest request)
        {

            var deleteMakeRequest = await repository.DeleteById(request.Id);
            var deleteMakeResponse = mapper.Map<DeleteVehicleMakeResponse>(deleteMakeRequest);

            return deleteMakeResponse;
        }
    }
}
