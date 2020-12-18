using AutoMapper;
using Project.DAL.Entities;
using Project.Model.VehicleMakeResource;
using Project.Model.VehicleModelResource;
using Project.WebAPI.Controllers.RestModels;

namespace Project.Model.Profiles
{
    public class VehicleMakeProfiles : Profile
    {
        public VehicleMakeProfiles()
        {
            CreateMap<VehicleMake, VehicleModel>()
                .ForMember(m => m.Make, opt => opt.MapFrom(s => s));
            CreateMap<VehicleMakeEntity, VehicleMake>()
                .ReverseMap();
            CreateMap<VehicleMake, ReadVehicleMake>();
            CreateMap<CreateParams, VehicleMake>();
        }
    }
}
