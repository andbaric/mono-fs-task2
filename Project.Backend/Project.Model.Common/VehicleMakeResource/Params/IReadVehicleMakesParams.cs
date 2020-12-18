using Project.Common.Paging;
using Project.Common.Sorting;

namespace Project.Model.Common.VehicleMakeResource.Params
{
    public interface IReadVehicleMakesParams : IPaging, IVehicleMakesFilter, ISorting
    {
    }
}
