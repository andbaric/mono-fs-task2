using AutoMapper;
using Project.DAL.Entities;
using Project.Model.Common.DTOs.VehicleMake.ReadVehicleMakes;
using Project.Model.DTOs.VehicleMake;

namespace Project.Model.Profiles
{
    public class VehicleMakeProfiles : Profile
    {
        public VehicleMakeProfiles()
        {
            CreateMap<CreateVehicleMakeRequest, VehicleMakeEntity>();

            CreateMap<VehicleMakeEntity, ReadVehicleMakeResponse>();
            CreateMap<VehicleMakeEntity, IReadVehicleMakesResponseItem>();

            CreateMap<ReadVehicleMakeResponse, UpdateVehicleMakeRequest>();
            CreateMap<UpdateVehicleMakeRequest, VehicleMakeEntity>();

            CreateMap<VehicleMakeEntity, DeleteVehicleMakeResponse>();
        }
    }
}
