using Project.Common.Paging;
using Project.Common.Sorting;

namespace Project.Model.Common.VehicleModelResource.Params
{
    public interface IReadVehicleModelsParams : IPaging, IVehicleModelsFilter, ISorting
    {
    }
}
