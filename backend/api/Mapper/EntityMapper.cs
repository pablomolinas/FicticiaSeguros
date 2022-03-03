using api.Interfaces;
using api.Models;
using api.Models.dto;

namespace api.Mapper
{
    public class EntityMapper : IEntityMapper
    {
        public Person PersonDtoForRegisterToPerson(PersonDtoForRegister dto)
        {
            var person = new Person()
            {
                Dni = dto.Dni,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Age = dto.Age,
                Gender = dto.Gender,
                Enable = dto.Enable,
                Drive = dto.Drive,
                Glasses = dto.Glasses,
                Diabetic = dto.Diabetic                
            };

            var diseases = new List<Disease>();
            if (dto.Diseases != null)
            {
                foreach (var d in dto.Diseases)
                {
                    diseases.Add(this.DiseaseForDisplayToDisease(d));
                }
            }
            person.Diseases = diseases;

            return person;
        }

        public PersonDtoForDisplay PersonToPersonDtoForDisplay(Person person)
        {
            var dto = new PersonDtoForDisplay()
            {
                Id = person.Id,
                Dni = person.Dni,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Age = person.Age,
                Gender = person.Gender,
                Enable = person.Enable,
                Drive = person.Drive,
                Glasses = person.Glasses,
                Diabetic = person.Diabetic                
            };

            var diseasesDto = new List<DiseaseForDisplay>();
            if (person.Diseases != null)
            {
                foreach (var d in person.Diseases)
                {
                    diseasesDto.Add(this.DiseaseToDiseaseForDisplay(d));
                }
            }

            dto.Diseases = diseasesDto;

            return dto;
        }
        
        public Disease DiseaseForDisplayToDisease(DiseaseForDisplay dto)
        {
            return new Disease()
            {
                Id = dto.Id,
                Name = dto.Name
            };
        }

        public DiseaseForDisplay DiseaseToDiseaseForDisplay(Disease disease)
        {
            return new DiseaseForDisplay()
            {
                Id = disease.Id,
                Name = disease.Name
            };
        }

        public Person PersonDtoForDisplayToPerson(PersonDtoForDisplay dto)
        {
            var person = new Person()
            {
                Id = dto.Id,
                Dni = dto.Dni,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Age = dto.Age,
                Gender = dto.Gender,
                Enable = dto.Enable,
                Drive = dto.Drive,
                Glasses = dto.Glasses,
                Diabetic = dto.Diabetic
            };

            var diseases = new List<Disease>();
            if (dto.Diseases != null)
            {
                foreach (var d in dto.Diseases)
                {
                    diseases.Add(this.DiseaseForDisplayToDisease(d));
                }
            }
            person.Diseases = diseases;

            return person;
        }
    }
}
