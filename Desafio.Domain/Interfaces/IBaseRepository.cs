using Desafio.Domain.Domain.Shared;
using System;

namespace Desafio.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : Entity
    {
        int Add(T obj);
        int Edit(T obj);
        int Remove(T obj);
        T FindById(Guid id);
        bool ObjExist(T obj);
    }
}
