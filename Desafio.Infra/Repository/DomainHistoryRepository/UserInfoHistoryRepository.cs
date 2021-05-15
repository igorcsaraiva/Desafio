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
    internal class UserInfoHistoryRepository : IUserInfoHistoryRepository
    {
        private readonly HistoryContext _requestsContext;

        public UserInfoHistoryRepository(HistoryContext requestsContext) => _requestsContext = requestsContext;
        public int Add(UserInfoHistory obj)
        {
            _requestsContext.Add(obj);
            return _requestsContext.SaveChanges();
        }

        public async Task<IEnumerable<UserInfoHistory>> FindAllByEntityId(Guid Id)
        {
            return await _requestsContext.UserInfoHistory.Where(x => x.Id == Id).ToListAsync();
        }

        public async Task<IEnumerable<UserInfoHistory>> FindAllByUserId(string userId)
        {
            return await _requestsContext.UserInfoHistory.Where(x => x.UserId == userId).ToListAsync();
        }
    }
}
