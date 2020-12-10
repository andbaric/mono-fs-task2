using System;

namespace Project.Model.Common.DTOs.VehicleModel
{
    public interface ICreateVehicleModelResponse : IVehicleModelDtoResponse
    {
        Guid MakeId { get; set; }

        Guid Id { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }
    }
}
