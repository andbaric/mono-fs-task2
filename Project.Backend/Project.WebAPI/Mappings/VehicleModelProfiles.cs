using AutoMapper;
using Project.DAL.Entities;
using Project.Model;
using Project.WebAPI.Controllers.RestModels;

namespace Project.WebAPI.Profiles
{
    public class VehicleModelProfiles : Profile
    {
        public VehicleModelProfiles()
        {
            CreateMap<VehicleModelEntity, VehicleModel>()
                .ReverseMap();
            CreateMap<VehicleMakeEntity, VehicleModel>()
                .ForMember(m => m.Make, opt => opt.MapFrom(s => s));
            CreateMap<VehicleModel, ReadVehicleModel>();
        }
    }
}
