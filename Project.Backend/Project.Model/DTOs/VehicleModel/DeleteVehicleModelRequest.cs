using Project.Model.Common.DTOs.VehicleModel;
using System;

namespace Project.Model.DTOs.VehicleModel
{
    public class DeleteVehicleModelRequest : IDeleteVehicleModelRequest
    {
        public Guid Id { get; set; }
    }
}
