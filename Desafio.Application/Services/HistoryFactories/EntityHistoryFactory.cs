using Desafio.Domain.Domain;
using Desafio.Domain.Domain.DomainHistory;
using Desafio.Domain.Domain.DomainHistory.Enums;
using Desafio.Domain.Domain.Shared;
using Desafio.Domain.Interfaces.DomainHistoryInterfaces;
using Microsoft.AspNetCore.Identity;
using System;

namespace Desafio.Application.Services.HistoryFactories
{
    internal class EntityHistoryFactory : IEntityHistoryFactory
    {
        public EntityHistory GetEntityHistory(object obj, RequestActionEnum requestActionEnum)
        {
            var type = obj.GetType();

            if (typeof(IdentityUser) == type)
            {
                var objEntity = obj as IdentityUser;
                return new AcountHistory { AcountEmail = objEntity.Email, Action = requestActionEnum, Date = DateTime.UtcNow, UserId = objEntity.Id };
            }
            if (typeof(PersonalNotes) == type)
            {
                var objEntity = obj as PersonalNotes;
                return new PersonalNoteHistory { Content = objEntity.Content, Action = requestActionEnum, Date = DateTime.UtcNow, UserId = objEntity.UserId, PersonalNoteId = objEntity.Id };
            }
            if (typeof(UserInfo) == type)
            {
                var objEntity = obj as UserInfo;
                return new UserInfoHistory { HomeTown = objEntity.HomeTown, Action = requestActionEnum, Date = DateTime.UtcNow, UserId = objEntity.UserId, Name = objEntity.Name, UserInfoId = objEntity.Id };
            }

            return null;
        }
    }
}
