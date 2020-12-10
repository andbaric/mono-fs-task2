using Project.Model.Common.DTOs.VehicleMake;
using System;

namespace Project.Model.DTOs.VehicleMake
{
    public class DeleteVehicleMakeRequest : IDeleteVehicleMakeRequest
    {
        public Guid Id { get; set; }
    }
}
