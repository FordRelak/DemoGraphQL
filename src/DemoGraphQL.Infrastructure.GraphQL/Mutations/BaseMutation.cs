using AutoMapper;

namespace DemoGraphQL.Infrastructure.GraphQL.Mutations
{
    public abstract class BaseMutation
    {
        protected readonly IMapper _mapper;

        public BaseMutation(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
