using System;

namespace Project.Model.Common.VehicleMakeResource
{
    public interface IVehicleMake
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }
    }
}
