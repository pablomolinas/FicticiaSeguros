using api.Models;
using api.Models.dto;
using api.Models.Response;

namespace api.Interfaces
{
    public interface IPersonsService
    {
        Task<Result> GetAll();
        Task<Result> GetById(int id);
        Task<Result> Insert(PersonDtoForRegister dto);
        Task<Result> Update(int id, PersonDtoForRegister dto);
        Task<Result> Delete(int id);
    }
}
