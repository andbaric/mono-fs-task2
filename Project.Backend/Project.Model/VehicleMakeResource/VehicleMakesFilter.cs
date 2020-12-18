using Project.Model.Common.VehicleMakeResource;

namespace Project.Model.VehicleMakeResource
{
    public class VehicleMakesFilter : IVehicleMakesFilter
    {
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}
