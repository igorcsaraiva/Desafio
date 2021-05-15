using System;
using System.ComponentModel.DataAnnotations;

namespace Desafio.Domain.Validation
{
    public class GuidValidation : ValidationAttribute
    {
        public GuidValidation()
        {
            ErrorMessage = "Invalid guid";
        }
        public override bool IsValid(object value)
        {
            var guid = value as string;

            return Guid.TryParse(guid, out Guid result);
        }
    }
}
