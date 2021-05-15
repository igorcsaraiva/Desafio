using Desafio.Application.RequestObject;
using Desafio.Domain.Validation;
using System.Threading.Tasks;

namespace Desafio.Application.Interfaces
{
    public interface IAcountService
    {
        Task<AcountResponse> Register(AcountRegisterRequest register);
        Task<AcountResponse> Login(AcountLoginRequest login);
        Task<AcountResponse> ForgotPassword(string email);
        Task<AcountResponse> ResetPassword(AcountResetPasswordRequest acountResetPassword);
        Task<AcountResponse> ResetLoggedPassword(AcountResetPasswordLoggedRequest acountResetPasswordLoggedRequest);
    }
}
