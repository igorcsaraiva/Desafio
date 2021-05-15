using Desafio.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace Desafio.Application.Services.AccessToExternalServices
{
    internal class SendGridMailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public SendGridMailService(IConfiguration configuration) => _configuration = configuration;

        public async Task<Response> SendEmailAsync(string toEmail, string subject, string content)
        {
            var client = new SendGridClient(_configuration["SendGrid:Key"]);
            var from = new EmailAddress("desafio.api@gmail.com");
            var to = new EmailAddress(toEmail);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, content, content);
            return await client.SendEmailAsync(msg);
        }
    }
}
