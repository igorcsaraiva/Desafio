using Desafio.Application.Interfaces;
using Desafio.Application.RequestObject;
using Desafio.Domain.Domain.DomainHistory;
using Desafio.Domain.Interfaces.DomainHistoryInterfaces;
using Desafio.Domain.Validation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Application.Services
{
    internal class AcountService : IAcountService
    {
        private readonly IIdentityService _identityService;
        private readonly ITokenService _tokenServices;
        private readonly IAcountHistoryRepository _acountHistoryRepository;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;
        private readonly IEntityHistoryFactory _entityHistoryFactory;

        public AcountService(ITokenService tokenServices,
                             IAcountHistoryRepository acountHistoryRepository,
                             IIdentityService identityService,
                             IEmailService emailService,
                             IConfiguration configuration,
                             IEntityHistoryFactory entityHistoryFactory)
        {
            _tokenServices = tokenServices;
            _acountHistoryRepository = acountHistoryRepository;
            _identityService = identityService;
            _emailService = emailService;
            _configuration = configuration;
            _entityHistoryFactory = entityHistoryFactory;
        }
        public async Task<AcountResponse> Login(AcountLoginRequest login)
        {
            var result = await _identityService.PasswordSignInAsync(login.Email, login.Password, false, false);

            if (result.Succeeded)
            {
                var user = await _identityService.FindByEmailAsync(login.Email);
                _acountHistoryRepository.Add(_entityHistoryFactory.GetEntityHistory(user, Domain.Domain.DomainHistory.Enums.RequestActionEnum.Logged) as AcountHistory);
                return new AcountResponse
                {
                    Message = "successfully logged in",
                    Token = _tokenServices.GenerateToken(login, user),
                    UserId = user.Id,
                    UserEmail = login.Email
                };
            }

            return new AcountResponse { Message = "One or more validation errors occurred.", Erros = new string[1] { "Incorrect user or password" } };
        }

        public async Task<AcountResponse> Register(AcountRegisterRequest register)
        {
            var identity = new IdentityUser
            {
                Email = register.Email,
                UserName = register.Email
            };

            var result = await _identityService.CreateAsync(identity, register.Password);

            if (result.Succeeded)
            {
                var user = await _identityService.FindByEmailAsync(identity.Email);
                _acountHistoryRepository.Add(_entityHistoryFactory.GetEntityHistory(user, Domain.Domain.DomainHistory.Enums.RequestActionEnum.Register) as AcountHistory);
                return new AcountResponse
                {
                    Message = "User Created sucessfully!!",
                };
            }

            return new AcountResponse { Message = "User did not create", Erros = result.Errors.Select(e => e.Description) };
        }

        public async Task<AcountResponse> ForgotPassword(string email)
        {
            var user = await _identityService.FindByEmailAsync(email);

            if (user is null)
                return new AcountResponse { Message = "One or more validation errors occurred.", Erros = new string[1] { "User not found!" } };

            var token = await _identityService.GeneratePasswordResetTokenAsync(user);

            var encodedToken = Encoding.UTF8.GetBytes(token);
            var validToken = WebEncoders.Base64UrlEncode(encodedToken);

            var urlReset = $"{_configuration["App:Url"]}" + $"/ResetPassword?email={email}&token={validToken}";
            var htmlContent = "<h1><p>Reset your password</p></h1> " +
                $"<p>To reset your password <a href='{urlReset}'>click here</a></p>";

            var result = await _emailService.SendEmailAsync(user.Email, "Reset password", htmlContent);

            if (result.IsSuccessStatusCode)
                return new AcountResponse { Message = "E-mail successfully sent" };

            return new AcountResponse { Message = "Something went wrong!", Erros = new string[1] { result.Body.ReadAsStringAsync().Result } };
        }

        public async Task<AcountResponse> ResetPassword(AcountResetPasswordRequest acountResetPassword)
        {
            var user = await _identityService.FindByEmailAsync(acountResetPassword.Email);

            if (user is null)
                return new AcountResponse { Message = "One or more validation errors occurred.", Erros = new string[1] { "User not found!" } };

            var encodedToken = WebEncoders.Base64UrlDecode(acountResetPassword.Token);
            var validToken = Encoding.UTF8.GetString(encodedToken);

            var result = await _identityService.ResetPasswordAsync(user, validToken, acountResetPassword.Password);

            if (result.Succeeded)
            {
                _acountHistoryRepository.Add(_entityHistoryFactory.GetEntityHistory(user, Domain.Domain.DomainHistory.Enums.RequestActionEnum.Update) as AcountHistory);
                return new AcountResponse { Message = "Password has been reset successfuly" };
            }

            return new AcountResponse { Message = "One or more validation errors occurred.", Erros = result.Errors.Select(e => e.Description) };
        }

        public async Task<AcountResponse> ResetLoggedPassword(AcountResetPasswordLoggedRequest acountResetPasswordLoggedRequest)
        {
            var user = await _identityService.FindByEmailAsync(acountResetPasswordLoggedRequest.Email);

            if (user is null)
                return new AcountResponse { Message = "One or more validation errors occurred.", Erros = new string[1] { "User not found!" } };

            var validToken = await _identityService.GeneratePasswordResetTokenAsync(user);

            var result = await _identityService.ResetPasswordAsync(user, validToken, acountResetPasswordLoggedRequest.Password);

            if (result.Succeeded)
            {
                _acountHistoryRepository.Add(_entityHistoryFactory.GetEntityHistory(user, Domain.Domain.DomainHistory.Enums.RequestActionEnum.Update) as AcountHistory);
                return new AcountResponse { Message = "Password has been reset successfuly" };
            }

            return new AcountResponse { Message = "One or more validation errors occurred.", Erros = result.Errors.Select(e => e.Description) };
        }
    }
}
