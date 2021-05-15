using Desafio.Domain.Domain.DomainHistory.Enums;
using Desafio.Domain.Domain.Shared;
using System;

namespace Desafio.Domain.Domain.DomainHistory
{
    public class UserInfoHistory : EntityHistory
    {
        public Guid UserInfoId { get; set; }
        public string Name { get; set; }
        public string HomeTown { get; set; }
        public DateTime Date { get; set; }
        public RequestActionEnum Action { get; set; }

        public UserInfoHistory()
        {
        }
    }
}
