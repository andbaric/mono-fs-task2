using Project.Common.Paging;
using Project.Model.Common.VehicleMakeResource.Params;

namespace Project.Model.VehicleMakeResource.Params
{
    public class ReadVehicleMakesParams : Paging, IReadVehicleMakesParams
    {
        public string Name { get; set; }
        public string Abrv { get; set; }

        public string OrderBy { get; set; } = "Name";
    }
}
