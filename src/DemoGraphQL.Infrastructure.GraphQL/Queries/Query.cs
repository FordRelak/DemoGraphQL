using DemoGraphQL.Application.DTO;
using DemoGraphQL.Application.Mediator.Queries.Books;
using MediatR;

namespace DemoGraphQL.Infrastructure.GraphQL.Queries
{
    public class Query
    {
        public async Task<IList<BookDTO>> GetBooks([Service] IMediator mediator, CancellationToken cancellationToken)
        {
            return await mediator.Send(new GetBooksQuery(), cancellationToken);
        }
    }
}
