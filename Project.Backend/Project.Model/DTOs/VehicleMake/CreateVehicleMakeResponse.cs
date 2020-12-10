using Project.Model.Common.DTOs.VehicleMake;
using System;

namespace Project.Model.DTOs.VehicleMake
{
    public class CreateVehicleMakeResponse : ICreateVehicleMakeResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}
