using Desafio.Application.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Desafio.Application.Services
{
    internal class IdentityService : IIdentityService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public IdentityService(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public Task<IdentityResult> CreateAsync(IdentityUser user, string password)
        {
            return _userManager.CreateAsync(user, password);
        }

        public Task<IdentityUser> FindByEmailAsync(string email)
        {
            return _userManager.FindByEmailAsync(email);
        }

        public Task<IdentityUser> FindByIdAsync(string userId)
        {
            return _userManager.FindByIdAsync(userId);
        }

        public Task<string> GeneratePasswordResetTokenAsync(IdentityUser user)
        {
            return _userManager.GeneratePasswordResetTokenAsync(user);
        }

        public Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure)
        {
            return _signInManager.PasswordSignInAsync(userName, password, isPersistent, lockoutOnFailure);
        }

        public Task<IdentityResult> ResetPasswordAsync(IdentityUser user, string token, string newPassword)
        {
            return _userManager.ResetPasswordAsync(user, token, newPassword);
        }
    }
}
