using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public bool SoftDelete { get; set; }

        [Required(ErrorMessage = "Dni es requerido")]
        [RegularExpression(@"^\d{7,9}$", ErrorMessage = "DNI incorrecto")]
        public string Dni { get; set; }


        [Required(ErrorMessage = "Nombre es requerido")]
        [StringLength(maximumLength: 100, ErrorMessage = "Nombre es demasiado largo")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Apellido es requerido")]
        [StringLength(maximumLength: 100, ErrorMessage = "Apellido es demasiado largo")]
        public string LastName { get; set; }
                
        [Required(ErrorMessage = "Edad es requerido")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Genero es requerido")]
        [RegularExpression(@"HOMBRE|MUJER$", ErrorMessage = "Genero incorrecto")]
        public string Gender { get; set; }
        
        public bool Enable { get; set; }
        public bool Drive { get; set; }
        public bool Glasses { get; set; }
        public bool Diabetic { get; set; }

        public virtual ICollection<DiseasePerson> DiseasesPersons { get; set; }
    }
}
