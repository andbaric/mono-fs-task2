using Project.Model.Common.DTOs.VehicleMake;

namespace Project.Model.DTOs.VehicleMake
{
    public class CreateVehicleMakeRequest : ICreateVehicleMakeRequest
    {
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}
