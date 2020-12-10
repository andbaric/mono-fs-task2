using System;
using System.ComponentModel.DataAnnotations;

namespace Project.Model.Common.DTOs.VehicleMake
{
    public interface IUpdateVehicleMakeRequest : IVehicleMakeDtoRequest
    {
        Guid Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}
