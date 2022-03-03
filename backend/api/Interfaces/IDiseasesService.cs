using api.Models.Response;

namespace api.Interfaces
{
    public interface IDiseasesService
    {
        Task<Result> GetAll();
    }
}
