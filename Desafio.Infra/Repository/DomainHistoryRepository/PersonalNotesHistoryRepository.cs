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
    internal class PersonalNotesHistoryRepository : IPersonalNotesHistoryRepository
    {
        private readonly HistoryContext _requestsContext;

        public PersonalNotesHistoryRepository(HistoryContext requestsContext) => _requestsContext = requestsContext;
        public int Add(PersonalNoteHistory obj)
        {
            _requestsContext.Add(obj);
            return _requestsContext.SaveChanges();
        }

        public async Task<IEnumerable<PersonalNoteHistory>> FindAllByEntityId(Guid Id)
        {
            return await _requestsContext.PersonalNoteHistory.Where(x => x.Id == Id).ToListAsync();
        }

        public async Task<IEnumerable<PersonalNoteHistory>> FindAllByUserId(string userId)
        {
            return await _requestsContext.PersonalNoteHistory.Where(x => x.UserId == userId).ToListAsync();
        }
    }
}
