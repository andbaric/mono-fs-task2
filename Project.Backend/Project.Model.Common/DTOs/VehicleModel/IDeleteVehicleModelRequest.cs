using System;

namespace Project.Model.Common.DTOs.VehicleModel
{
    public interface IDeleteVehicleModelRequest : IVehicleModelDtoRequest
    {
        Guid Id { get; set; }
    }
}
