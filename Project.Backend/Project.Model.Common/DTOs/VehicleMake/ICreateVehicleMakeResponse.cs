using System;

namespace Project.Model.Common.DTOs.VehicleMake
{
    public interface ICreateVehicleMakeResponse : IVehicleMakeDtoResponse
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }
    }
}
