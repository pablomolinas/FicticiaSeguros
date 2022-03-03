using api.Models;
using api.Models.dto;

namespace api.Interfaces
{
    public interface IEntityMapper
    {
        Person PersonDtoForRegisterToPerson(PersonDtoForRegister dto);
        PersonDtoForDisplay PersonToPersonDtoForDisplay(Person person);
        Person PersonDtoForDisplayToPerson(PersonDtoForDisplay dto);
        DiseaseForDisplay DiseaseToDiseaseForDisplay(Disease disease);
        public Disease DiseaseForDisplayToDisease(DiseaseForDisplay dto);
    }
}
