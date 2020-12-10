using Project.Model.Common.DTOs;
using Project.Model.Common.DTOs.VehicleModel;
using System;

namespace Project.Model.DTOs.VehicleModel
{
    public class CreateVehicleModelResponse : ICreateVehicleModelResponse
    {
        public Guid MakeId { get; set; }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }    
    }
}
