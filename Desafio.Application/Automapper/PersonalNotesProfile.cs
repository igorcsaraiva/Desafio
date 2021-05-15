using AutoMapper;
using Desafio.Application.RequestObject;
using Desafio.Application.ResponseObject;
using Desafio.Domain.Domain;

namespace Desafio.Application.Automapper
{
    internal class PersonalNotesProfile : Profile
    {
        public PersonalNotesProfile()
        {
            CreateMap<PersonalNoteRequest, PersonalNotes>().ReverseMap();
            CreateMap<PersonalNoteResponse, PersonalNotes>().ReverseMap()
            .ForMember(x => x.Content, opt => opt.MapFrom(x => x.DecryptContent(x.Content)));
        }
    }
}
