using System;
using Project.Model.Common.VehicleMakeResource;
using System.ComponentModel.DataAnnotations;

namespace Project.Model.VehicleMakeResource
{
    public class VehicleMake : IVehicleMake
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Abrv { get; set; }
    }
}
