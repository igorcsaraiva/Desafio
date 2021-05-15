using AutoMapper;
using Desafio.Application.RequestObject;
using Desafio.Application.ResponseObject;
using Desafio.Domain.Domain;

namespace Desafio.Application.Automapper
{
    internal class UserInfoProfile : Profile
    {
        public UserInfoProfile()
        {
            CreateMap<UserInfoRequest, UserInfo>().ReverseMap();
            CreateMap<UserInfoResponse, UserInfo>().ReverseMap();
        }
    }
}
