using AutoMapper;
using DemoGraphQL.Application.DTO;
using DemoGraphQL.Domain;

namespace DemoGraphQL.Application.Mapper.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDTO>().ReverseMap();
        }
    }
}