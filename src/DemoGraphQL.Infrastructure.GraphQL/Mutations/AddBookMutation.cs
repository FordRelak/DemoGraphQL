using AutoMapper;
using DemoGraphQL.Application.Mediator.Handlers.Books;
using DemoGraphQL.Domain;
using DemoGraphQL.Infrastructure.GraphQL.Types.Books;
using MediatR;

namespace DemoGraphQL.Infrastructure.GraphQL.Mutations
{
    [ExtendObjectType(typeof(Mutation))]
    public class AddBookMutation : BaseMutation
    {
        public AddBookMutation(IMapper mapper) : base(mapper)
        {
        }

        public async Task<Book> AddBookAsync(
            AddBookType book,
            [Service] IMediator mediator,
            CancellationToken cancellationToken)
        {
            return await mediator.Send(new AddBookCommand(_mapper.Map<Book>(book)), cancellationToken);
        }
    }
}
