namespace DemoGraphQL.Application.Mediator.Queries.Books
{
    public record GetBooksQuery : IRequest<IList<Book>>;
}
