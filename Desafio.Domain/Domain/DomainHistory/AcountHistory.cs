using Desafio.Domain.Domain.DomainHistory.Enums;
using Desafio.Domain.Domain.Shared;
using System;

namespace Desafio.Domain.Domain.DomainHistory
{
    public class AcountHistory : EntityHistory
    {
        public DateTime Date { get; set; }
        public RequestActionEnum Action { get; set; }
        public string AcountEmail { get; set; }
        public AcountHistory()
        {

        }
    }
}
