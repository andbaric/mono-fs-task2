using System;
using System.ComponentModel.DataAnnotations;

namespace Project.Model.Common.DTOs.VehicleModel
{
    public interface IUpdateVehicleModelRequest : IVehicleModelDtoRequest
    {
        [Required]
        Guid Id { get; set; }
        [Required]
        Guid MakeId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Abrv { get; set; }
    }
}
