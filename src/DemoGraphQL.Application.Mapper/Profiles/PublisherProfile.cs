using AutoMapper;
using DemoGraphQL.Application.DTO;
using DemoGraphQL.Domain;

namespace DemoGraphQL.Application.Mapper.Profiles
{
    public class PublisherProfile : Profile
    {
        public PublisherProfile()
        {
            CreateMap<Publisher, PublisherDTO>().ReverseMap();
        }
    }
}