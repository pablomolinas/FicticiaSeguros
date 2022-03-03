using api.Models.dto;
using api.Models.Response;

namespace api.Interfaces
{
    public interface IUsersService
    {
        Task<Result> LoginAsync(UserDtoLogin dto);
    }
}
