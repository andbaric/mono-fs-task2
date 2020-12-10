using System;

namespace Project.Model.Common.DTOs.VehicleModel.ReadVehicleModels
{
    public interface IReadVehicleModelsResponseItem
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
