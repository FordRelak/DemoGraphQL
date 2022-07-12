namespace DemoGraphQL.Application.Mediator.Queries.Bases
{
    public abstract class BaseQueryHandler<T, U> : IRequestHandler<T, U> where T : IRequest<U>
    {
        protected BaseQueryHandler()
        {
        }

        public abstract Task<U> Handle(T request, CancellationToken cancellationToken);
    }
}
