using System;
using System.ComponentModel.DataAnnotations;

namespace Project.Model.Common.DTOs.VehicleModel
{
    public interface ICreateVehicleModelRequest : IVehicleModelDtoRequest
    {
        [Required]
        Guid MakeId { get; set; }

        [Required]
        Guid Id { get; set; }
        [Required]
        string Name { get; set; }
        [Required]
        string Abrv { get; set; }
    }
}
