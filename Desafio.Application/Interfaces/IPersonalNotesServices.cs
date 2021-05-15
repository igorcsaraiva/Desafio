using Desafio.Application.RequestObject;
using Desafio.Application.ResponseObject;
using Desafio.Domain.Validation;
using System;
using System.Collections.Generic;

namespace Desafio.Application.Interfaces
{
    public interface IPersonalNotesServices
    {
        ValidationResponse RegisterPersonalNotes(PersonalNoteRequest personalNoteRequest);
        ValidationResponse EditPersonalNotes(PersonalNoteRequest personalNoteRequest);
        PersonalNoteResponse FindPersonalNote(Guid id);
        IEnumerable<PersonalNoteResponse> FindAllPersonalNote(string userId);
        ValidationResponse DeletePersonalNotes(Guid id);
    }
}
