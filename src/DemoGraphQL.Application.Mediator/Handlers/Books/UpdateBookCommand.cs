namespace DemoGraphQL.Application.Mediator.Handlers.Books
{
    public record UpdateBookCommand(Book Book) : IRequest<Book>;
}
