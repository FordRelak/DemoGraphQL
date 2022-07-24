namespace DemoGraphQL.Application.Mediator.Queries.Publishers.GetPublishersByIds
{
    public record GetPublishersByIdsQuery(Guid[] Ids) : IRequest<IList<Publisher>>;
}
