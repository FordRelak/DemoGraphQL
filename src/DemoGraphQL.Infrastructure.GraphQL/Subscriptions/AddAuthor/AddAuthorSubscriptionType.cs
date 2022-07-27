using DemoGraphQL.Domain;
using DemoGraphQL.Infrastructure.GraphQL.Types;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;

namespace DemoGraphQL.Infrastructure.GraphQL.Subscriptions.AddAuthor
{
    public class AddAuthorSubscriptionType : ObjectTypeExtension<Subscription>
    {
        protected override void Configure(IObjectTypeDescriptor<Subscription> descriptor)
        {
            descriptor
                .Field(nameof(AuthorAddedResolver.AuthorAdded).ToGqlName())
                .Description("Срабатывает когда добавляется новый автор")
                .Type<AuthorType>()
                .ResolveWith<AuthorAddedResolver>(resolver => resolver.AuthorAdded(default!))
                .Subscribe(async context =>
                {
                    ITopicEventReceiver receiver = context.Service<ITopicEventReceiver>();

                    ISourceStream<Author> stream = await receiver.SubscribeAsync<string, Author>(nameof(AuthorAddedResolver.AuthorAdded));

                    return stream;
                });
        }

        private class AuthorAddedResolver
        {
            public Author AuthorAdded([EventMessage] Author author)
            {
                return author;
            }
        }
    }
}
