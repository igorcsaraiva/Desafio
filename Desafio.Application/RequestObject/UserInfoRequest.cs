using Desafio.Domain.Validation;
using System.ComponentModel.DataAnnotations;

namespace Desafio.Application.RequestObject
{
    public class UserInfoRequest
    {
        [Required]
        public string UserId { get; set; }

        [GuidValidation]
        [Required]
        public string Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public string HomeTown { get; set; }
    }
}
