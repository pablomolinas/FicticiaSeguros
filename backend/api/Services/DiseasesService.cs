using api.Interfaces;
using api.Models.dto;
using api.Models.Response;

namespace api.Services
{
    public class DiseasesService : IDiseasesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEntityMapper _entityMapper;
        public DiseasesService(IUnitOfWork unitOfWork, IEntityMapper entityMapper)
        {
            _unitOfWork = unitOfWork;
            _entityMapper = entityMapper;
        }

        public async Task<Result> GetAll()
        {
            try
            {
                var diseases = await _unitOfWork.DiseasesRepository.FindByConditionAsync(x => !x.SoftDelete);
                if(diseases.Count > 0)
                {
                    var dtoList = new List<DiseaseForDisplay>();
                    foreach(var d in diseases)
                    {
                        dtoList.Add(_entityMapper.DiseaseToDiseaseForDisplay(d));
                    }

                    return Result<ICollection<DiseaseForDisplay>>.SuccessResult(dtoList);
                }

                return Result.FailureResult("No existen enfermedades", 404);
                
            } catch (Exception ex)
            {
                return Result.ErrorResult(new List<string>() { ex.Message });
            }
        }
    }
}
