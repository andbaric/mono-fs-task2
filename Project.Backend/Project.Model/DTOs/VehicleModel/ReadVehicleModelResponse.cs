using Project.Model.Common.DTOs.VehicleModel;
using System;

namespace Project.Model.DTOs.VehicleModel
{
    public class ReadVehicleModelResponse : IReadVehicleModelResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set ; }
        public VehicleMake Make { get; set; }
    }
    public class VehicleMake : IVehicleMake
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
