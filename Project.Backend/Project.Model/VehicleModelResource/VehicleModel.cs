using Project.Model.Common.VehicleModelResource;
using Project.Model.VehicleMakeResource;
using System.ComponentModel.DataAnnotations;
using System;

namespace Project.Model.VehicleModelResource
{
    public class VehicleModel : IVehicleModel<VehicleMake>
    {
        public VehicleMake Make { get; set; }

        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Abrv { get; set; }
    }
}
