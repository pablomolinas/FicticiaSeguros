using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Disease
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre es requerido")]
        [StringLength(maximumLength: 150, ErrorMessage = "Nombre es demasiado largo")]
        public string Name { get; set; }
    }
}
