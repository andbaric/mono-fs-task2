using Project.Model.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace Project.Model
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
