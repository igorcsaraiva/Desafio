using Desafio.Domain.Validation;
using System.ComponentModel.DataAnnotations;

namespace Desafio.Application.RequestObject
{
    public class PersonalNoteRequest
    {
        [GuidValidation]
        [Required]
        public string Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
