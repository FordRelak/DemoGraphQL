namespace DemoGraphQL.Infrastructure.GraphQL.Mutations.AddBook
{
    public record AddBookInput(string Title, Guid AuthorId, Guid PublisherId);
}
