using AutoMapper;
using DemoGraphQL.Application.Mediator.Handlers.Books;
using DemoGraphQL.Domain;
using DemoGraphQL.Infrastructure.GraphQL.Types.Books;
using HotChocolate.Subscriptions;
using MediatR;

namespace DemoGraphQL.Infrastructure.GraphQL.Mutations.Books
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
            [Service] ITopicEventSender sender,
            CancellationToken cancellationToken)
        {
            Book newBook = await mediator.Send(new AddBookCommand(_mapper.Map<Book>(book)), cancellationToken);

            await sender.SendAsync(newBook.Id, newBook, cancellationToken);

            return newBook;
        }
    }
}
