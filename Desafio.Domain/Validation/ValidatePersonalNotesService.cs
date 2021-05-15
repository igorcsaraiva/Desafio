using Desafio.Domain.Domain;
using Desafio.Domain.Interfaces;
using System.Collections.Generic;

namespace Desafio.Domain.Validation
{
    public class ValidatePersonalNotesService : IValidatePersonalNotes
    {
        private readonly IPersonalNotesRepository _personalNotesRepository;

        public ValidatePersonalNotesService(IPersonalNotesRepository personalNotesRepository) => _personalNotesRepository = personalNotesRepository;

        public ValidationResponse ValidateAddition(PersonalNotes Obj)
        {
            var msg = new List<string>(2);

            if (string.IsNullOrEmpty(Obj.Content) && string.IsNullOrWhiteSpace(Obj.Content))
                msg.Add("invalid content");
            if (_personalNotesRepository.ObjExist(Obj))
                msg.Add("This personal note already has this content added, consider editing them");

            if (msg.Count > 0)
                return new ValidationResponse { Message = "One or more validation errors occurred.", Erros = msg };

            return new ValidationResponse();
        }

        public ValidationResponse ValidateEdit(PersonalNotes Obj)
        {
            var msg = new List<string>(2);

            if (string.IsNullOrEmpty(Obj.Content) && string.IsNullOrWhiteSpace(Obj.Content))
                msg.Add("invalid content");
            if (_personalNotesRepository.ObjExist(Obj) is not true)
                msg.Add("This personal note does not exist");

            if (msg.Count > 0)
                return new ValidationResponse { Message = "One or more validation errors occurred.", Erros = msg };

            return new ValidationResponse { Message = "no errors found" };
        }

        public ValidationResponse ValidateRemoval(PersonalNotes Obj)
        {
            var msg = new List<string>(1);

            if (_personalNotesRepository.ObjExist(Obj) is not true)
                msg.Add("This personal note does not exist");

            if (msg.Count > 0)
                return new ValidationResponse { Message = "One or more validation errors occurred.", Erros = msg };

            return new ValidationResponse { Message = "no errors found" };
        }
    }
}
