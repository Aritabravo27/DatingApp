using entities;

namespace Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}