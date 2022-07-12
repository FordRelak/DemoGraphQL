namespace DemoGraphQL.Application.Mediator.Queries.Publishers
{
    public record GetPublishersQuery : IRequest<IList<Publisher>>;
}
