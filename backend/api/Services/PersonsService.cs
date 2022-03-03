using api.Interfaces;
using api.Models;
using api.Models.dto;
using api.Models.Response;

namespace api.Services
{
    public class PersonsService : IPersonsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEntityMapper _entityMapper;
        public PersonsService(IUnitOfWork unitOfWork, IEntityMapper entityMapper)
        {
            _unitOfWork = unitOfWork;
            _entityMapper = entityMapper;
        }

        public async Task<Result> GetAll()
        {
            try
            {
                var persons = await _unitOfWork.PersonsRepository.FindByConditionAsync(x => x.SoftDelete == false);
                if (persons.Count > 0)
                {
                    var dtoList = new List<PersonDtoForDisplay>();
                    foreach(var p in persons)
                    {
                        dtoList.Add(_entityMapper.PersonToPersonDtoForDisplay(p));
                    }

                    return Result<ICollection<PersonDtoForDisplay>>.SuccessResult(dtoList);
                }

                return Result.FailureResult("No hay Resultados", 404);
            }
            catch (Exception ex)
            {
                return Result.ErrorResult(new List<string> { ex.Message });
            }
        }

        public async Task<Result> GetById(int id)
        {
            try
            {
                var person = await _unitOfWork.PersonsRepository.GetByIdAsync(id);
                if (person != null)
                {
                    return Result<PersonDtoForDisplay>.SuccessResult(_entityMapper.PersonToPersonDtoForDisplay(person));
                }

                return Result.FailureResult("Persona inexistente", 404);
            }
            catch (Exception ex)
            {
                return Result.ErrorResult(new List<string> { ex.Message });
            }
        }

        public async Task<Result> Insert(PersonDtoForRegister dto)
        {
            try
            {
                var person = _entityMapper.PersonDtoForRegisterToPerson(dto);
                                
                await _unitOfWork.PersonsRepository.CreateAsync(person);
                
                return Result<PersonDtoForDisplay>.SuccessResult(_entityMapper.PersonToPersonDtoForDisplay(person));                
            }
            catch (Exception ex)
            {
                return Result.ErrorResult(new List<string> { ex.Message });
            }
        }

        public async Task<Result> Update(int id, PersonDtoForRegister dto)
        {
            try
            {
                var person = await _unitOfWork.PersonsRepository.GetByIdAsync(id);                
                if(person != null && !person.SoftDelete)
                {                    
                    person.Dni = dto.Dni;
                    person.FirstName = dto.FirstName;
                    person.LastName = dto.LastName;
                    person.Gender = dto.Gender;
                    person.Age = dto.Age;
                    person.Drive = dto.Drive;
                    person.Diabetic = dto.Diabetic;
                    person.Enable = dto.Enable;
                    person.Glasses = dto.Glasses;
                    
                    if (person.Diseases != null)
                    {
                        foreach(var d in person.Diseases)
                        {
                            person.Diseases.Remove(d);
                        }                        
                    }                    

                    if(dto.Diseases.Count > 0)
                    {
                        person.Diseases = new List<Disease>();
                        foreach (var d in dto.Diseases)
                        {
                            person.Diseases.Add(_entityMapper.DiseaseForDisplayToDisease(d));
                        }
                    }
                    await _unitOfWork.SaveChangesAsync();

                    return Result<PersonDtoForDisplay>.SuccessResult(_entityMapper.PersonToPersonDtoForDisplay(person));
                }
                
                return Result.FailureResult("Persona inexistente", 404);
            }
            catch (Exception ex)
            {
                return Result.ErrorResult(new List<string> { ex.Message });
            }
        }

        /// <summary>
        ///     Logic Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result> Delete(int id)
        {
            try
            {   
                var person = await _unitOfWork.PersonsRepository.GetByIdAsync(id);
                if (person != null && !person.SoftDelete)
                {
                    person.SoftDelete = true;
                    await _unitOfWork.SaveChangesAsync();

                    return Result<int>.SuccessResult(person.Id);
                }

                return Result.FailureResult("Persona inexistente", 404);
            }
            catch (Exception ex)
            {
                return Result.ErrorResult(new List<string> { ex.Message });
            }
        }

    }
}
