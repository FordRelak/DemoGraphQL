using DemoGraphQL.Domain;
using HotChocolate.Subscriptions;

namespace DemoGraphQL.Infrastructure.GraphQL.Mutations.AddBook
{
    public class AddBookMutationExtension : ObjectTypeExtension<Mutation>
    {
        protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
        {
            descriptor
                .Field(nameof(AddBookResolver.AddBookAsync).ToGqlName())
                .Argument("input", argument => argument.Type<NonNullType<AddBookInputType>>())
                .ResolveWith<AddBookResolver>(resolver => resolver.AddBookAsync(default!, default!, default!, default))
                .UseDbContext<GQDbContext>();
        }

        private class AddBookResolver
        {
            public async Task<AddBookPayload> AddBookAsync(
                AddBookInput input,
                [ScopedService] GQDbContext context,
                [Service] ITopicEventSender topicEventSender,
                CancellationToken cancellationToken)
            {
                Book book = new()
                {
                    Title = input.Title,
                    AuthorId = input.AuthorId,
                    PublisherId = input.PublisherId,
                };

                await context.AddAsync(book, cancellationToken);
                await context.SaveChangesAsync(cancellationToken);

                await topicEventSender.SendAsync($"{input.AuthorId}_BookAddedToAuthor", book, cancellationToken);

                return new(book.Id);
            }
        }
    }
}
