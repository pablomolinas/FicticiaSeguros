using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }

        public bool SoftDelete { get; set; }
    }
}
