using Project.Model.Common.DTOs.VehicleModel.ReadVehicleModels;
using System;

namespace Project.Model.DTOs.VehicleModel.ReadVehicleModels
{
    public class ReadVehicleModelsResponseItem : IReadVehicleModelsResponseItem
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public VehicleMake Make { get; set; }
    }

    public class VehicleMake : IVehicleMake
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
