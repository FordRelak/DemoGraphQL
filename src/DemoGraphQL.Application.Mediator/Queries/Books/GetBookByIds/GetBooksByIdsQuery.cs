namespace DemoGraphQL.Application.Mediator.Queries.Books.GetBookByIds
{
    public record GetBooksByIdsQuery(Guid[] Ids) : IRequest<IList<Book>>;
}
