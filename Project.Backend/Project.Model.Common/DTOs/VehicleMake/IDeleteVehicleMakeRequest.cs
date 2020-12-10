using System;

namespace Project.Model.Common.DTOs.VehicleMake
{
    public interface IDeleteVehicleMakeRequest : IVehicleMakeDtoRequest
    {
        Guid Id { get; set; }
    }
}
