using Project.Model.Common.DTOs.VehicleModel;
using System;

namespace Project.Model.DTOs.VehicleModel
{
    public class ReadVehicleModelRequest : IReadVehicleModelRequest
    {
        public Guid Id { get; set; }
    }
}
