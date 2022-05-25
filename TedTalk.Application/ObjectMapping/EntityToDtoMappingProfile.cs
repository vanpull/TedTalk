using AutoMapper;
using TedTalk.Application.Contracts.Dtos;
using TedTalk.Domain.Entities;

namespace TedTalk.Application.ObjectMapping
{
    public class EntityToDtoMappingProfile : Profile
    {
        public EntityToDtoMappingProfile()
        {
            CreateMap<Ted, TedDto>().ReverseMap();
        }
    }
}
