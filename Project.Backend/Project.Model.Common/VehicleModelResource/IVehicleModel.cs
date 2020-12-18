using Project.Model.Common.VehicleMakeResource;
using System;

namespace Project.Model.Common.VehicleModelResource
{
    public interface IVehicleModel<TDependency> where TDependency : IVehicleMake
    {
        TDependency Make { get; set; }
        Guid Id { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }
    }
}
