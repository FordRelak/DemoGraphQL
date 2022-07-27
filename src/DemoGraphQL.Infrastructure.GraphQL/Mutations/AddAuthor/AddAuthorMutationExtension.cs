using DemoGraphQL.Domain;
using HotChocolate.Subscriptions;

namespace DemoGraphQL.Infrastructure.GraphQL.Mutations.AddAuthor
{
    public class AddAuthorMutationExtension : ObjectTypeExtension<Mutation>
    {
        protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
        {
            descriptor
                .Field(nameof(AddAuthorResolver.AddAuthorAsync).ToGqlName())
                .Argument("input", argument => argument.Type<NonNullType<AddAuthorInputType>>())
                .ResolveWith<AddAuthorResolver>(resolver => resolver.AddAuthorAsync(default!, default!, default!, default))
                .UseDbContext<GQDbContext>()
                .Description("Добавление автора");
        }

        private class AddAuthorResolver
        {
            public async Task<AddAuthorPayload> AddAuthorAsync(
                AddAuthorInput input,
                [ScopedService] GQDbContext context,
                [Service] ITopicEventSender topicEventSender,
                CancellationToken cancellationToken)
            {
                Author author = new()
                {
                    Name = input.Name,
                };

                await context.AddAsync(author, cancellationToken);
                await context.SaveChangesAsync(cancellationToken);

                await topicEventSender.SendAsync("AuthorAdded", author, cancellationToken);

                return new(author.Id, author.Name);
            }
        }
    }
}
