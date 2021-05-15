using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Desafio.Application.Interfaces
{
    public interface IIdentityService
    {
        Task<IdentityUser> FindByIdAsync(string userId);
        Task<IdentityUser> FindByEmailAsync(string email);
        Task<IdentityResult> CreateAsync(IdentityUser user, string password);
        Task<string> GeneratePasswordResetTokenAsync(IdentityUser user);
        Task<IdentityResult> ResetPasswordAsync(IdentityUser user, string token, string newPassword);
        Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure);
    }
}
