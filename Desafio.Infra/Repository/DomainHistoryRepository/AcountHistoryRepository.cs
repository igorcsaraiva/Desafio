using Desafio.Domain.Domain.DomainHistory;
using Desafio.Domain.Interfaces.DomainHistoryInterfaces;
using Desafio.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.Infra.Repository.DomainHistoryRepository
{
    internal class AcountHistoryRepository : IAcountHistoryRepository
    {
        private readonly HistoryContext _requestsContext;

        public AcountHistoryRepository(HistoryContext requestsContext) => _requestsContext = requestsContext;

        public int Add(AcountHistory obj)
        {
            _requestsContext.Add(obj);
            return _requestsContext.SaveChanges();
        }

        public async Task<IEnumerable<AcountHistory>> FindAllByEntityId(Guid Id)
        {
            return await _requestsContext.AcountHistory.Where(x => x.Id == Id).ToListAsync();
        }

        public async Task<IEnumerable<AcountHistory>> FindAllByUserId(string userId)
        {
            return await _requestsContext.AcountHistory.Where(x => x.UserId == userId).ToListAsync();
        }
    }
}
