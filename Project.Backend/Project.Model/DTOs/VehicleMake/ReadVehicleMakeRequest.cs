using Project.Model.Common.DTOs.VehicleMake;
using System;

namespace Project.Model.DTOs.VehicleMake
{
    public class ReadVehicleMakeRequest : IReadVehicleMakeRequest
    {
        public Guid Id { get; set; }
    }
}
