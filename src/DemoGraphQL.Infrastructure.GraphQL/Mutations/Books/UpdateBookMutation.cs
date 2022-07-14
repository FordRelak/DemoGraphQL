using AutoMapper;
using DemoGraphQL.Application.Mediator.Handlers.Books;
using DemoGraphQL.Domain;
using DemoGraphQL.Infrastructure.GraphQL.Types.Books;
using HotChocolate.Subscriptions;
using MediatR;

namespace DemoGraphQL.Infrastructure.GraphQL.Mutations.Books
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
            [Service] ITopicEventSender sender,
            CancellationToken cancellationToken)
        {
            Book updatedBook = await mediator.Send(new UpdateBookCommand(_mapper.Map<Book>(book)), cancellationToken);

            await sender.SendAsync(updatedBook.Id, updatedBook);

            return updatedBook;
        }
    }
}
