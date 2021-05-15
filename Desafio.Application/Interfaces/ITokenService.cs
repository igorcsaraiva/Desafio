using Desafio.Application.RequestObject;
using Microsoft.AspNetCore.Identity;

namespace Desafio.Application.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(AcountLoginRequest login, IdentityUser user);
    }
}
