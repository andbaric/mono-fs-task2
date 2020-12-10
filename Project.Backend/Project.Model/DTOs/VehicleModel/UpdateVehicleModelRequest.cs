using Project.Model.Common.DTOs.VehicleModel;
using System;
using System.ComponentModel.DataAnnotations;

namespace Project.Model.DTOs.VehicleModel
{
    public class UpdateVehicleModelRequest : IUpdateVehicleModelRequest
    {
        public Guid MakeId { get; set; }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}
