using api.Models;

namespace api.Interfaces
{
    public interface IJwtHelper
    {
        public string GenerateJwtToken(User user);
    }
}
