using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.DAL.Entities
{
    [Table("vehicle_make")]
    public class VehicleMakeEntity : EntityModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Abrv { get; set; }
    }
}
