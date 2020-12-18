using Project.Common.Paging;
using Project.Model.Common.VehicleModelResource.Params;

namespace Project.Model.VehicleModelResoure.Params
{
    public class ReadVehicleModelsParams : Paging, IReadVehicleModelsParams
    {
        public string Name { get; set; }
        public string Abrv { get; set; }
        public string MakeName { get; set; }
        public string OrderBy { get; set; } = "Name";
    }
}
