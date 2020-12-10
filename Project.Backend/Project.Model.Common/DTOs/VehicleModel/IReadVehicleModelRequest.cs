using System;

namespace Project.Model.Common.DTOs.VehicleModel
{
    public interface IReadVehicleModelRequest : IVehicleModelDtoRequest
    {
        Guid Id { get; set; }
    }
}
