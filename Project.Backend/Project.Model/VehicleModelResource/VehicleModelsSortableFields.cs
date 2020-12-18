using Project.Model.Common.VehicleModelResource;

namespace Project.Model.VehicleModelResource
{
    public class VehicleModelsSortableFields : IVehicleModelsSortableFields
    {
        public string Name { get; set; }
        public string Abrv { get; set; }
        public string MakeName { get; set; }
    }
}
