using AutoMapper;
using Project.DAL.Entities;
using Project.Model.Common.DTOs.VehicleModel.ReadVehicleModels;
using Project.Model.DTOs.VehicleModel;

namespace Project.WebAPI.Profiles
{
    public class VehicleModelProfiles : Profile
    {
        public VehicleModelProfiles()
        {
            CreateMap<CreateVehicleModelRequest, VehicleModelEntity>();

            CreateMap<VehicleModelEntity, ReadVehicleModelResponse>();
            CreateMap<VehicleModelEntity, IReadVehicleModelsResponseItem>();

            CreateMap<ReadVehicleModelResponse, UpdateVehicleModelRequest>()
                .ForMember(d => d.MakeId, opt => opt.MapFrom(s => s.Make.Id));
            CreateMap<UpdateVehicleModelRequest, VehicleModelEntity>();

            CreateMap<VehicleModelEntity, DeleteVehicleModelResponse>();
        }
    }
}
