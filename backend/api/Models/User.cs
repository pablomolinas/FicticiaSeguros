using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public bool SoftDelete { get; set; }

        [Required(ErrorMessage = "Nombre es requerido")]
        [StringLength(maximumLength: 100, ErrorMessage = "Nombre es demasiado largo")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Apellido es requerido")]
        [StringLength(maximumLength: 100, ErrorMessage = "Apellido es demasiado largo")]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "Email es requerido")]
        [StringLength(maximumLength: 320, ErrorMessage = "Email es demasiado largo")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password es requerido")]
        [StringLength(maximumLength: 255, ErrorMessage = "Password es demasiado largo")]        
        public string Password { get; set; }
    }
}
