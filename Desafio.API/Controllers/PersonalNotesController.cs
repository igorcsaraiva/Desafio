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
    public class PersonalNotesController : ControllerBase
    {
        private readonly IPersonalNotesServices _personalNotesServices;

        public PersonalNotesController(IPersonalNotesServices personalNotesServices) => _personalNotesServices = personalNotesServices;

        [HttpPost("RegisterPersonalNote")]
        public ActionResult RegisterPersonalNote(PersonalNoteRequest personalNoteRequest)
        {

            if (ModelState.IsValid)
            {
                var result = _personalNotesServices.RegisterPersonalNotes(personalNoteRequest);

                if (result.IsSuccess)
                    return Ok(result);

                return BadRequest(result);
            }

            return BadRequest("Some properties are not valid!");
        }

        [HttpGet("FindPersonalNote/{id}")]
        public ActionResult FindPersonalNote(Guid id)
        {
            var personalNote = _personalNotesServices.FindPersonalNote(id);

            if (personalNote is null)
                return NotFound("There is no personal note");

            return Ok(personalNote);
        }

        [HttpGet("FindAllPersonalNote/{userId}")]
        public ActionResult FindAllPersonalNote(string userId)
        {
            var personalNote = _personalNotesServices.FindAllPersonalNote(userId);

            return Ok(personalNote);
        }

        [HttpPut("EditPersonalNote")]
        public ActionResult EditPersonalNote(PersonalNoteRequest personalNoteRequest)
        {

            if (ModelState.IsValid)
            {
                var result = _personalNotesServices.EditPersonalNotes(personalNoteRequest);

                if (result.IsSuccess)
                    return Ok(result);

                return BadRequest(result);
            }

            return BadRequest("Some properties are not valid!");
        }

        [HttpDelete("RemovePersonalNote/{id}")]
        public ActionResult RemovePersonalNote(Guid id)
        {
            var result = _personalNotesServices.DeletePersonalNotes(id);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);

        }
    }
}
