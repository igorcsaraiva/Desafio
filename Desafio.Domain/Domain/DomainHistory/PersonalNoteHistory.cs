using Desafio.Domain.Domain.DomainHistory.Enums;
using Desafio.Domain.Domain.Shared;
using System;

namespace Desafio.Domain.Domain.DomainHistory
{
    public class PersonalNoteHistory : EntityHistory
    {
        public Guid PersonalNoteId { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public RequestActionEnum Action { get; set; }

        public PersonalNoteHistory()
        {
        }
    }
}
