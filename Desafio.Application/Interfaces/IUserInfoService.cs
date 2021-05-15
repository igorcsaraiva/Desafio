using Desafio.Application.RequestObject;
using Desafio.Application.ResponseObject;
using Desafio.Domain.Validation;
using System;

namespace Desafio.Application.Interfaces
{
    public interface IUserInfoService
    {
        ValidationResponse RegisterInfo(UserInfoRequest registerInfoRequest);
        ValidationResponse EditInfo(UserInfoRequest registerInfoRequest);
        UserInfoResponse FindUserInfo(string userId);
        ValidationResponse DeleteInfo(Guid infoId);
        RecommendedPlaylistResponse RecommendedPlaylist(string userId);
    }
}
