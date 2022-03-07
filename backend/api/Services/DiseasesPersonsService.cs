using api.Interfaces;
using api.Models;
using api.Models.dto;
using api.Models.Response;

namespace api.Services
{
    public class DiseasesPersonsService : IDiseasesPersonsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEntityMapper _entityMapper;
        public DiseasesPersonsService(IUnitOfWork unitOfWork, IEntityMapper entityMapper)
        {
            _unitOfWork = unitOfWork;
            _entityMapper = entityMapper;
        }

        public async Task<ICollection<DiseasePerson>> GetAllById(int personId)
        {

            var dp = await _unitOfWork.DiseasesPersonsRepository.FindByConditionAsync(x => x.PersonId == personId);            
            return dp;
        }

        public async Task<Result> Insert(int PersonId, int DiseaseId) {
            try
            {
                return Result.SuccessResult();
            }
            catch (Exception ex)
            {
                return Result.ErrorResult(new List<string> { ex.Message });
            }
        }

        public async Task<Result> InsertRange(int personId, ICollection<DiseaseForDisplay> diseases)
        {
            try
            {
                var d = new List<DiseasePerson>();
                foreach(var x in diseases)
                {
                    d.Add(new DiseasePerson() { PersonId = personId, DiseaseId = x.Id });
                }

                await _unitOfWork.DiseasesPersonsRepository.CreateRangeAsync(d);
                await _unitOfWork.SaveChangesAsync();

                return Result.SuccessResult();
            }
            catch (Exception ex)
            {
                return Result.ErrorResult(new List<string> { ex.Message });
            }
        }

        public async Task DeleteRange(int PersonId) 
        {            
            var dp = await GetAllById(PersonId);
            if(dp.Count > 0)
            {
                _unitOfWork.DiseasesPersonsRepository.RemoveRange(dp);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
