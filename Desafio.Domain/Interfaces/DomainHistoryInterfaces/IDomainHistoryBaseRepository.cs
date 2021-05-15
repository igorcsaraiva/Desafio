using Desafio.Domain.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desafio.Domain.Interfaces.DomainHistoryInterfaces
{
    public interface IDomainHistoryBaseRepository<T> where T : Entity
    {
        int Add(T obj);
        Task<IEnumerable<T>> FindAllByUserId(string userId);
        Task<IEnumerable<T>> FindAllByEntityId(Guid Id);
    }
}
