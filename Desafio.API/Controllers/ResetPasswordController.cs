using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Desafio.API.Controllers
{
    [Route("[controller]")]
    public class ResetPasswordController : Controller
    {
        private readonly IConfiguration _configuration;

        public ResetPasswordController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Index(string email, string token)
        {
            ViewBag.Token = token;
            ViewBag.Email = email;
            ViewBag.AppUrlReset = _configuration["App:Url"] + "/api/Acount/ResetPassword";
            return View(nameof(Index));
        }
    }
}
