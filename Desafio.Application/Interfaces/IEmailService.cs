using SendGrid;
using System.Threading.Tasks;

namespace Desafio.Application.Interfaces
{
    public interface IEmailService
    {
        Task<Response> SendEmailAsync(string toEmail, string subject, string content);
    }
}
