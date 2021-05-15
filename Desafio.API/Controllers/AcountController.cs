using Desafio.Application.Interfaces;
using Desafio.Application.RequestObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Desafio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcountController : ControllerBase
    {
        private readonly IAcountService _acountServices;
        public AcountController(IAcountService acountServices)
        {
            _acountServices = acountServices;
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(AcountRegisterRequest register)
        {
            if (ModelState.IsValid)
            {
                var result = await _acountServices.Register(register);

                if (result.IsSuccess)
                    return Ok(result);

                return BadRequest(result);
            }

            return BadRequest("Some properties are not valid");
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(AcountLoginRequest login)
        {
            if (ModelState.IsValid)
            {
                var result = await _acountServices.Login(login);

                if (result.IsSuccess)
                    return Ok(result);

                return BadRequest(result);
            }

            return BadRequest("Some properties are not valid");
        }

        [HttpPost("ForgotPassword")]
        public async Task<ActionResult> ForgotPassword(string email)
        {
            var result = await _acountServices.ForgotPassword(email);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut("ResetPassword")]
        public async Task<ActionResult> ResetPassword(AcountResetPasswordRequest acountResetPassword)
        {
            if (ModelState.IsValid)
            {
                var result = await _acountServices.ResetPassword(acountResetPassword);

                if (result.IsSuccess)
                    return Ok(result);

                return BadRequest(result);
            }

            return BadRequest("Some properties are not valid");
        }

        [HttpPut("ResetLoggedPassword")]
        [Authorize]
        public async Task<ActionResult> ResetLoggedPassword(AcountResetPasswordLoggedRequest acountResetPasswordLoggedRequest)
        {
            if (ModelState.IsValid)
            {
                var result = await _acountServices.ResetLoggedPassword(acountResetPasswordLoggedRequest);

                if (result.IsSuccess)
                    return Ok(result);

                return BadRequest(result);
            }

            return BadRequest("Some properties are not valid");
        }
    }
}
