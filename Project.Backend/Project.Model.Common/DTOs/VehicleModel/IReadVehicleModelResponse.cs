using System;

namespace Project.Model.Common.DTOs.VehicleModel
{
    public interface IReadVehicleModelResponse : IVehicleModelDtoResponse
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }
    }

    public interface IVehicleMake
    {
        Guid Id { get; set; }
        string Name { get; set; }
    }
}
