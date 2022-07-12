using AutoMapper;
using DemoGraphQL.Application.Mediator.Handlers.Books;
using DemoGraphQL.Domain;
using DemoGraphQL.Infrastructure.GraphQL.Types.Books;
using MediatR;

namespace DemoGraphQL.Infrastructure.GraphQL.Mutations
{
    [ExtendObjectType(typeof(Mutation))]
    public class UpdateBookMutation : BaseMutation
    {
        public UpdateBookMutation(IMapper mapper) : base(mapper)
        {
        }

        public async Task<Book> UpdateBookAsync(
            UpdateBookType book,
            [Service] IMediator mediator,
            CancellationToken cancellationToken)
        {
            return await mediator.Send(new UpdateBookCommand(_mapper.Map<Book>(book)), cancellationToken);
        }
    }
}
