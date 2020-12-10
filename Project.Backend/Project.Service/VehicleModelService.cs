using AutoMapper;
using Project.DAL.Entities;
using Project.Model.Common.DTOs.VehicleModel;
using Project.Model.Common.DTOs.VehicleModel.ReadVehicleModels;
using Project.Model.DTOs.VehicleModel;
using Project.Model.DTOs.VehicleModel.ReadVehicleModels;
using Project.Repository.Common;
using Project.Service.Common;
using System;
using System.Threading.Tasks;

namespace Project.Service
{
    public class VehicleModelService : IVehicleModelService
    {
        public readonly IVehicleModelRespository repository;
        private readonly IMapper mapper;

        public VehicleModelService(IVehicleModelRespository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<ICreateVehicleModelResponse> CreateVehicleModel(ICreateVehicleModelRequest request)
        {
            var makeToCreateEntity = mapper.Map<VehicleModelEntity>(request);
            await repository.Create(makeToCreateEntity);

            return null;
        }

        public async Task<IReadVehicleModelResponse> ReadVehicleModel(IReadVehicleModelRequest request)
        {
            var modelToRead = await repository.GetById(request.Id);
            var readMakeResponse = mapper.Map<ReadVehicleModelResponse>(modelToRead);

            return readMakeResponse;
        }

        public async Task<IReadVehicleModelsResponse> ReadVehicleModels(IReadVehicleModelsRequest request)
        {
            var modelsToReadEntitieCollection = await repository.GetAll();
            var readMakesResponse = mapper.Map<ReadVehicleModelsResponse>(modelsToReadEntitieCollection);

            return readMakesResponse;
        }

        public async Task<IUpdateVehicleModelResponse> UpdateVehicleModel(IUpdateVehicleModelRequest request)
        {
            var modelToUpdateEntity = mapper.Map<VehicleModelEntity>(request);
            await repository.Update(modelToUpdateEntity);

            return null;
        }

        public async Task<IDeleteVehicleModelResponse> DeleteVehicleModel(IDeleteVehicleModelRequest request)
        {
            var deleteModelEntity = await repository.DeleteById(request.Id);
            var deleteModelResponse = mapper.Map<DeleteVehicleModelResponse>(deleteModelEntity);

            return deleteModelResponse;      
        }
    }
}
