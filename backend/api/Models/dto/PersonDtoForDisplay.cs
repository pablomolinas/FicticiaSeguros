namespace api.Models.dto
{
    public class PersonDtoForDisplay
    {
        public int Id { get; set; }
        public string Dni { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }        
        public int Age { get; set; }
        public string Gender { get; set; }
        public bool Enable { get; set; }
        public bool Drive { get; set; }
        public bool Glasses { get; set; }
        public bool Diabetic { get; set; }
        public virtual ICollection<DiseaseForDisplay> Diseases { get; set; }
    }
}
