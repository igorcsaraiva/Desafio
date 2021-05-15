using Desafio.Domain.Domain.DomainHistory.Enums;
using Desafio.Domain.Domain.Shared;

namespace Desafio.Domain.Interfaces.DomainHistoryInterfaces
{
    public interface IEntityHistoryFactory
    {
        EntityHistory GetEntityHistory(object obj, RequestActionEnum requestActionEnum);
    }
}
