using System;

namespace Project.Model.Common.DTOs.VehicleMake
{
    public interface IReadVehicleMakeRequest : IVehicleMakeDtoRequest
    {
        Guid Id { get; set; }
    }
}
