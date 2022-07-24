namespace DemoGraphQL.Application.Mediator.Queries.Publishers.GetPublishers
{
    public record GetPublishersQuery : IRequest<IList<Publisher>>;
}
