using Project.Model.Common.DTOs.VehicleMake.ReadVehicleMakes;
using System;

namespace Project.Model.DTOs.VehicleMake.ReadVehicleMakes
{
    public class ReadVehicleMakesResponseItem : IReadVehicleMakesResponseItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}
