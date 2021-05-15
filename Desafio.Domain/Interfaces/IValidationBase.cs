using Desafio.Domain.Domain.Shared;
using Desafio.Domain.Validation;

namespace Desafio.Domain.Interfaces
{
    public interface IValidationBase<T> where T : Entity
    {
        ValidationResponse ValidateAddition(T Obj);
        ValidationResponse ValidateEdit(T Obj);
        ValidationResponse ValidateRemoval(T Obj);
    }
}
