using Desafio.Domain.Domain;

namespace Desafio.Domain.Interfaces
{
    public interface IUserInfoRepository : IBaseRepository<UserInfo>
    {
        UserInfo FindByUserId(string id);
    }
}
