using Project.Model.VehicleMakeResource;
using System;

namespace Project.WebAPI.Controllers.RestModels
{
    public class ReadVehicleModel
    {
        public VehicleMake Make { get; set; }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}
