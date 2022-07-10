namespace DemoGraphQL.Application.Mediator.Queries.Authors
{
    public record GetAuthorsQuery : IRequest<IList<AuthorDTO>>;
}