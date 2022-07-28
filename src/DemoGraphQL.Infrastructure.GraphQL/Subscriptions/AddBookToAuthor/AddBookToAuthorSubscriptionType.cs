using DemoGraphQL.Domain;
using DemoGraphQL.Infrastructure.GraphQL.Types;
using HotChocolate.Subscriptions;

namespace DemoGraphQL.Infrastructure.GraphQL.Subscriptions.AddBookToAuthor
{
    public class AddBookToAuthorSubscriptionType : ObjectTypeExtension<Subscription>
    {
        protected override void Configure(IObjectTypeDescriptor<Subscription> descriptor)
        {
            descriptor
                .Field(nameof(AddBookToAuthorResolver.BookAddedToAuthor).ToGqlName())
                .Argument("authorId", argument => argument.Type<NonNullType<IdType>>())
                .Description("Срабатывает когда к автору добавляется книга")
                .Type<BookType>()
                .ResolveWith<AddBookToAuthorResolver>(resolver => resolver.BookAddedToAuthor(default!, default!))
                .UseDbContext<GQDbContext>()
                .UseProjection()
                .UseFirstOrDefault()
                .Subscribe(async context =>
                {
                    var receiver = context.Service<ITopicEventReceiver>();
                    string authorId = context.ArgumentValue<string>("authorId");

                    var topic = $"{authorId}_BookAddedToAuthor";

                    var stream = await receiver.SubscribeAsync<string, Book>(topic);

                    return stream;
                });
        }

        private class AddBookToAuthorResolver
        {
            public IQueryable<Book> BookAddedToAuthor([EventMessage] Book newBook, [ScopedService] GQDbContext context)
            {
                return context.Books.Where(book => book.Id == newBook.Id);
            }
        }
    }
}
