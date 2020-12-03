using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.DAL.Entities
{
    [Table("vehicle_model")]
    public class VehicleModel : EntityBase
    {
        [Required]
        public Guid MakeId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Abrv { get; set; }
    }
}
