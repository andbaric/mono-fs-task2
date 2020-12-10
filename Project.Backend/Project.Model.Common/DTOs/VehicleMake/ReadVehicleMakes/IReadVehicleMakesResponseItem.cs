using System;

namespace Project.Model.Common.DTOs.VehicleMake.ReadVehicleMakes
{
    public interface IReadVehicleMakesResponseItem : IVehicleMakeDto
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }
    }
}
