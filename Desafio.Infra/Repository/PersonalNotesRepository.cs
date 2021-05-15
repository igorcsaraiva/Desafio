using Desafio.Domain.Domain;
using Desafio.Domain.Interfaces;
using Desafio.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.Infra.Repository
{
    internal class PersonalNotesRepository : IPersonalNotesRepository
    {
        private readonly Context _context;
        public PersonalNotesRepository(Context context) => _context = context;
        public int Add(PersonalNotes obj)
        {
            _context.Add(obj);
            return _context.SaveChanges();
        }

        public int Edit(PersonalNotes obj)
        {
            _context.Update(obj);
            return _context.SaveChanges();
        }

        public async Task<IEnumerable<PersonalNotes>> FindAllById(string userId)
        {
            return await _context.PersonalNotes.AsNoTracking().Where(x => x.UserId == userId).ToListAsync();
        }

        public PersonalNotes FindById(Guid id)
        {
            return _context.PersonalNotes.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public bool ObjExist(PersonalNotes obj)
        {
            if (obj is not null)
                return _context.PersonalNotes.Where(x => x.Id == obj.Id).Count() > 0;

            return false;
        }

        public int Remove(PersonalNotes obj)
        {
            _context.Remove(obj);
            return _context.SaveChanges();
        }
    }
}
