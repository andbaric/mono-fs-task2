using System.ComponentModel.DataAnnotations;

namespace Project.Model.Common.DTOs.VehicleMake
{
    public interface ICreateVehicleMakeRequest : IVehicleMakeDtoRequest
    {
        [Required]
        string Name { get; set; }
        [Required]
        string Abrv { get; set; }
    }
}
