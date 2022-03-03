using api.Interfaces;
using api.Models.dto;
using api.Helpers;
using api.Models.Response;

namespace api.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtHelper _jwtHelper;
        public UsersService(IUnitOfWork unitOfWork, IJwtHelper jwtHelper)
        {
            _unitOfWork = unitOfWork;
            _jwtHelper = jwtHelper;
        }

        public async Task<Result> LoginAsync(UserDtoLogin dto)
        {
            try
            {
                var result = await this._unitOfWork.UsersRepository.FindByConditionAsync(x => x.Email == dto.Email);

                if (result.Count > 0)
                {
                    var currentUser = result.FirstOrDefault();
                    if (currentUser != null)
                    {
                        var resultPassword = EncryptHelper.Verify(dto.Password, currentUser.Password);
                        if (resultPassword)
                        {
                            return Result<string>.SuccessResult(_jwtHelper.GenerateJwtToken(currentUser));
                        }
                    }
                }

                return Result.FailureResult("No se pudo iniciar sesion, usuario o contrasena invalidos");
            }
            catch (Exception e)
            {
                return Result.ErrorResult(new List<string> { e.Message });
            }
        }
    }
}
