using AutoMapper;
using Desafio.Application.Interfaces;
using Desafio.Application.RequestObject;
using Desafio.Application.ResponseObject;
using Desafio.Domain.Domain;
using Desafio.Domain.Domain.DomainHistory;
using Desafio.Domain.Interfaces;
using Desafio.Domain.Interfaces.DomainHistoryInterfaces;
using Desafio.Domain.Validation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Desafio.Application.Services
{
    internal class PersonalNoteService : IPersonalNotesServices
    {
        private readonly IPersonalNotesRepository _personalNotesRepository;
        private readonly IValidatePersonalNotes _validatePersonalNotes;
        private readonly IMapper _mapper;
        private readonly IIdentityService _identityService;
        private readonly IPersonalNotesHistoryRepository _personalNotesHistoryRepository;
        private readonly IEntityHistoryFactory _entityHistoryFactory;

        public PersonalNoteService(IPersonalNotesRepository personalNotesRepository,
                                   IValidatePersonalNotes validatePersonalNotes,
                                   IMapper mapper,
                                   IPersonalNotesHistoryRepository personalNotesHistoryRepository,
                                   IIdentityService identityService,
                                   IEntityHistoryFactory entityHistoryFactory)
        {
            _personalNotesRepository = personalNotesRepository;
            _validatePersonalNotes = validatePersonalNotes;
            _mapper = mapper;
            _personalNotesHistoryRepository = personalNotesHistoryRepository;
            _identityService = identityService;
            _entityHistoryFactory = entityHistoryFactory;
        }

        public ValidationResponse DeletePersonalNotes(Guid id)
        {
            var personalNote = _personalNotesRepository.FindById(id);

            var result = _validatePersonalNotes.ValidateRemoval(personalNote);

            if (result.IsSuccess)
            {
                if (_personalNotesRepository.Remove(personalNote) > 0)
                {
                    _personalNotesHistoryRepository.Add((_entityHistoryFactory.GetEntityHistory(personalNote, Domain.Domain.DomainHistory.Enums.RequestActionEnum.Delete) as PersonalNoteHistory));
                    result.Message = "Personal note has ben Removed";
                    return result;
                }
            }

            return result;
        }

        public ValidationResponse EditPersonalNotes(PersonalNoteRequest personalNoteRequest)
        {
            if (UserExists(personalNoteRequest.UserId) is null)
            {
                return CatchErrorForNonExistentIdentity();
            }

            var personalNote = _mapper.Map<PersonalNotes>(personalNoteRequest);

            var result = _validatePersonalNotes.ValidateEdit(personalNote);

            if (result.IsSuccess)
            {
                if (_personalNotesRepository.Edit(personalNote) > 0)
                {
                    _personalNotesHistoryRepository.Add(_entityHistoryFactory.GetEntityHistory(personalNote, Domain.Domain.DomainHistory.Enums.RequestActionEnum.Update) as PersonalNoteHistory);
                    result.Message = "Personal note has ben Edited";
                    return result;
                }
            }

            return result;
        }

        public IEnumerable<PersonalNoteResponse> FindAllPersonalNote(string userId)
        {
            return _mapper.Map<IEnumerable<PersonalNoteResponse>>(_personalNotesRepository.FindAllById(userId).Result);
        }

        public PersonalNoteResponse FindPersonalNote(Guid id)
        {
            return _mapper.Map<PersonalNoteResponse>(_personalNotesRepository.FindById(id));
        }

        public ValidationResponse RegisterPersonalNotes(PersonalNoteRequest personalNoteRequest)
        {
            if (UserExists(personalNoteRequest.UserId) is null)
            {
                return CatchErrorForNonExistentIdentity();
            }

            var personalNote = _mapper.Map<PersonalNotes>(personalNoteRequest);

            var result = _validatePersonalNotes.ValidateAddition(personalNote);

            if (result.IsSuccess)
            {
                if (_personalNotesRepository.Add(personalNote) > 0)
                {
                    _personalNotesHistoryRepository.Add(_entityHistoryFactory.GetEntityHistory(personalNote, Domain.Domain.DomainHistory.Enums.RequestActionEnum.Register) as PersonalNoteHistory);
                    result.Message = "Personal note has ben Add";
                    return result;
                }
            }

            return result;
        }

        private IdentityUser UserExists(string userId)
        {
            return _identityService.FindByIdAsync(userId).Result;
        }

        private ValidationResponse CatchErrorForNonExistentIdentity()
        {
            return new ValidationResponse
            {
                Message = "One or more validation errors occurred.",
                Erros = new string[1] { "This id has no users in that database" }
            };
        }
    }
}
