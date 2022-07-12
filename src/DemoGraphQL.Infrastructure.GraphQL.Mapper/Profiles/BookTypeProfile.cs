using AutoMapper;
using DemoGraphQL.Domain;
using DemoGraphQL.Infrastructure.GraphQL.Types.Books;

namespace DemoGraphQL.Infrastructure.GraphQL.Mapper.Profiles
{
    public class BookTypeProfile : Profile
    {
        public BookTypeProfile()
        {
            CreateMap<AddBookType, Book>();
            CreateMap<UpdateBookType, Book>();
        }
    }
}
