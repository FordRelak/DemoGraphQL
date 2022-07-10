namespace DemoGraphQL.Application.Mediator.Queries.Bases
{
    public abstract class BaseQueryHandler<T, U> : IRequestHandler<T, U> where T : IRequest<U>
    {
        protected readonly IMapper _mapper;

        protected BaseQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public abstract Task<U> Handle(T request, CancellationToken cancellationToken);
    }
}