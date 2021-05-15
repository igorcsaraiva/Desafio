using Desafio.Domain.Domain;
using Desafio.Domain.Interfaces;
using Desafio.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Desafio.Infra.Repository
{
    internal class UserInfoRepository : IUserInfoRepository
    {
        private readonly Context _context;
        public UserInfoRepository(Context context) => _context = context;

        public int Add(UserInfo obj)
        {
            _context.Add(obj);
            return _context.SaveChanges();
        }

        public int Edit(UserInfo obj)
        {
            _context.Update(obj);
            return _context.SaveChanges();
        }

        public UserInfo FindById(Guid id)
        {
            return _context.UserInfo.AsNoTrackingWithIdentityResolution().FirstOrDefault(x => x.Id == id);
        }

        public int Remove(UserInfo obj)
        {
            _context.Remove(obj);
            return _context.SaveChanges();
        }

        public bool ObjExist(UserInfo obj)
        {
            if (obj is not null)
                return _context.UserInfo.Where(x => x.Id == obj.Id).Count() > 0;

            return false;
        }

        public UserInfo FindByUserId(string id)
        {
            return _context.UserInfo.FirstOrDefault(x => x.UserId == id);
        }
    }
}
