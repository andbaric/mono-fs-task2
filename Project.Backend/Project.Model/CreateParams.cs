using Project.Model.Common;
using System.ComponentModel.DataAnnotations;

namespace Project.Model
{
    public class CreateParams : ICreateParams
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Abrv { get; set; }
    }
}
