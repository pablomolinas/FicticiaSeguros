using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Disease : EntityBase
    {
        [Required(ErrorMessage = "Nombre es requerido")]
        [StringLength(maximumLength: 150, ErrorMessage = "Nombre es demasiado largo")]
        public string Name { get; set; }

        public virtual ICollection<Person> Persons { get; set; }
    }
}
