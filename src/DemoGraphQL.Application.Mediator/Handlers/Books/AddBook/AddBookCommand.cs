namespace DemoGraphQL.Application.Mediator.Handlers.Books
{
    public record AddBookCommand(Book Book) : IRequest<Book>;
}
