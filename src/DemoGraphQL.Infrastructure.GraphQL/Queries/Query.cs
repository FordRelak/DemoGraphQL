using DemoGraphQL.Application.DTO;
using DemoGraphQL.Application.Mediator.Queries.Books;
using MediatR;

namespace DemoGraphQL.Infrastructure.GraphQL.Queries
{
    public class Query
    {
        private readonly IMediator _mediator;

        public Query(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IList<BookDTO>> GetBooks(CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetBooksQuery(), cancellationToken);
        }
    }
}