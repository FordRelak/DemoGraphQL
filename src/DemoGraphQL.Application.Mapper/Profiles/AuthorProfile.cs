using AutoMapper;
using DemoGraphQL.Application.DTO;
using DemoGraphQL.Domain;

namespace DemoGraphQL.Application.Mapper.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorDTO>().ReverseMap();
        }
    }
}