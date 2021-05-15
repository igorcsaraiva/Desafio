using Desafio.Application.Interfaces;
using Desafio.Application.RequestObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Desafio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserInfoService _userInfoService;

        public UserController(IUserInfoService userInfoService) => _userInfoService = userInfoService;

        [HttpPost("RegisterInfo")]
        public ActionResult RegisterInfo(UserInfoRequest userInfoRequest)
        {

            if (ModelState.IsValid)
            {
                var result = _userInfoService.RegisterInfo(userInfoRequest);

                if (result.IsSuccess)
                    return Ok(result);

                return BadRequest(result);
            }

            return BadRequest("Some properties are not valid!");
        }

        [HttpGet("FindInfo/{userId}")]
        public ActionResult FindInfo(string userId)
        {
            var userInfo = _userInfoService.FindUserInfo(userId);

            if (userInfo is null)
                return NotFound("There is no user information");

            return Ok(userInfo);
        }

        [HttpGet("RecommendedPlaylist/{userId}")]
        public ActionResult RecommendedPlaylist(string userId)
        {
            var result = _userInfoService.RecommendedPlaylist(userId);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut("EditInfo")]
        public ActionResult EditInfo(UserInfoRequest userInfoRequest)
        {

            if (ModelState.IsValid)
            {
                var result = _userInfoService.EditInfo(userInfoRequest);

                if (result.IsSuccess)
                    return Ok(result);

                return BadRequest(result);
            }

            return BadRequest("Some properties are not valid!");
        }

        [HttpDelete("RemoveInfo/{id}")]
        public ActionResult RemoveInfo(Guid id)
        {
            var result = _userInfoService.DeleteInfo(id);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);

        }
    }
}
