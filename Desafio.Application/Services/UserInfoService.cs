using AutoMapper;
using Desafio.Application.Interfaces;
using Desafio.Application.RequestObject;
using Desafio.Application.ResponseObject;
using Desafio.Domain.Domain;
using Desafio.Domain.Domain.DomainHistory;
using Desafio.Domain.Interfaces;
using Desafio.Domain.Interfaces.DomainHistoryInterfaces;
using Desafio.Domain.Structs;
using Desafio.Domain.Validation;
using Microsoft.AspNetCore.Identity;
using System;

namespace Desafio.Application.Services
{
    internal class UserInfoService : IUserInfoService
    {
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly IMapper _mapper;
        private readonly IIdentityService _identityService;
        private readonly IValidateUserInfo _validateUserInfo;
        private readonly IOpenWeatherService _openWeatherService;
        private readonly IRecommendedSpotifyPlaylistService _recommendedSpotifyPlaylistService;
        private readonly IUserInfoHistoryRepository _userInfoHistoryRepository;
        private readonly IEntityHistoryFactory _entityHistoryFactory;
        public UserInfoService(IUserInfoRepository userInfoRepository,
            IMapper mapper,
            IValidateUserInfo validateUserInfo,
            IOpenWeatherService openWeatherService,
            IRecommendedSpotifyPlaylistService recommendedSpotifyPlaylistService,
            IUserInfoHistoryRepository userInfoHistoryRepository,
            IIdentityService identityService,
            IEntityHistoryFactory entityHistoryFactory)
        {
            _userInfoRepository = userInfoRepository;
            _mapper = mapper;
            _validateUserInfo = validateUserInfo;
            _openWeatherService = openWeatherService;
            _recommendedSpotifyPlaylistService = recommendedSpotifyPlaylistService;
            _userInfoHistoryRepository = userInfoHistoryRepository;
            _identityService = identityService;
            _entityHistoryFactory = entityHistoryFactory;
        }

        public ValidationResponse RegisterInfo(UserInfoRequest registerInfoRequest)
        {
            if (UserExists(registerInfoRequest.UserId) is null)
            {
                return CatchErrorForNonExistentIdentity();
            }

            var userInfo = _mapper.Map<UserInfo>(registerInfoRequest);

            var result = _validateUserInfo.ValidateAddition(userInfo);

            if (result.IsSuccess)
            {
                if (_userInfoRepository.Add(userInfo) > 0)
                {
                    _userInfoHistoryRepository.Add(_entityHistoryFactory.GetEntityHistory(userInfo, Domain.Domain.DomainHistory.Enums.RequestActionEnum.Register) as UserInfoHistory);
                    result.Message = "User info has ben add";
                    return result;
                }
            }

            return result;
        }

        public ValidationResponse EditInfo(UserInfoRequest registerInfoRequest)
        {
            if (UserExists(registerInfoRequest.UserId) is null)
            {
                return CatchErrorForNonExistentIdentity();
            }

            var userInfo = _mapper.Map<UserInfo>(registerInfoRequest);

            var result = _validateUserInfo.ValidateEdit(userInfo);

            if (result.IsSuccess)
            {
                if (_userInfoRepository.Edit(userInfo) > 0)
                {
                    _userInfoHistoryRepository.Add(_entityHistoryFactory.GetEntityHistory(userInfo, Domain.Domain.DomainHistory.Enums.RequestActionEnum.Update) as UserInfoHistory);
                    result.Message = "User info has ben Edited";
                    return result;
                }
            }

            return result;
        }

        public UserInfoResponse FindUserInfo(string userId)
        {
            return _mapper.Map<UserInfoResponse>(_userInfoRepository.FindByUserId(userId));
        }

        public RecommendedPlaylistResponse RecommendedPlaylist(string userId)
        {
            if (UserExists(userId) is null)
            {
                var error = CatchErrorForNonExistentIdentity();
                return new RecommendedPlaylistResponse { Erros = error.Erros, Message = error.Message };
            }

            var userInfo = _userInfoRepository.FindByUserId(userId);

            if (userInfo is null)
                return new RecommendedPlaylistResponse { Erros = new string[1] { "User without registered information" }, Message = "One or more validation errors occurred." };

            var result = _openWeatherService.GetCurrentTemperatureHometown(userInfo);

            if (result.IsSuccess)
            {
                var temp = Temperature.ParseKelvinForCelcius(_openWeatherService.WeatherResponse.Main.temp);
                var cat = SuggestMusicalCategory.CategoryAccordingToTemperature(temp);

                return _recommendedSpotifyPlaylistService.GetPlaylist(cat);
            }

            return new RecommendedPlaylistResponse { Erros = result.Erros, Message = result.Message };
        }

        public ValidationResponse DeleteInfo(Guid id)
        {
            var userInfo = _userInfoRepository.FindById(id);

            var result = _validateUserInfo.ValidateRemoval(userInfo);

            if (result.IsSuccess)
            {
                if (_userInfoRepository.Remove(userInfo) > 0)
                {
                    _userInfoHistoryRepository.Add(_entityHistoryFactory.GetEntityHistory(userInfo, Domain.Domain.DomainHistory.Enums.RequestActionEnum.Delete) as UserInfoHistory);
                    result.Message = "User info has ben Removed";
                    return result;
                }
            }

            return result;
        }

        private IdentityUser UserExists(string userId)
        {
            return _identityService.FindByIdAsync(userId).Result;
        }

        private ValidationResponse CatchErrorForNonExistentIdentity()
        {
            return new ValidationResponse
            {
                Message = "One or more validation errors occurred.",
                Erros = new string[1] { "This id has no users in that database" }
            };
        }
    }
}
