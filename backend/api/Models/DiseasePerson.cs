

namespace api.Models
{
    public class DiseasePerson
    {
        
        public int DiseaseId { get; set; }        
        public int PersonId { get; set; }

        public virtual Disease Disease { get; set; }
        public virtual Person Person { get; set; }
    }
}
