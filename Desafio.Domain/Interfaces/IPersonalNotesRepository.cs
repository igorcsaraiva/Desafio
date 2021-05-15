using Desafio.Domain.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desafio.Domain.Interfaces
{
    public interface IPersonalNotesRepository : IBaseRepository<PersonalNotes>
    {
        Task<IEnumerable<PersonalNotes>> FindAllById(string userId);
    }
}
