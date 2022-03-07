using api.Models;
using api.Models.dto;
using api.Models.Response;

namespace api.Interfaces
{
    public interface IDiseasesPersonsService
    { 
        Task<ICollection<DiseasePerson>> GetAllById(int personId);
        Task<Result> Insert(int PersonId, int DiseaseId);
        Task<Result> InsertRange(int PersonId, ICollection<DiseaseForDisplay> diseases);        
        Task DeleteRange(int PersonId);
    }
}
