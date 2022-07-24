namespace DemoGraphQL.Application.Mediator.Queries.Publishers.GetPublishersByIds
{
    public class GetPublishersByIdsQueryHandler : IRequestHandler<GetPublishersByIdsQuery, IList<Publisher>>
    {
        private readonly IRepository<Publisher> _publisherRepository;

        public GetPublishersByIdsQueryHandler(IRepository<Publisher> publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        public async Task<IList<Publisher>> Handle(GetPublishersByIdsQuery request, CancellationToken cancellationToken)
        {
            return await _publisherRepository.ListAsync(new Specifications.Publishers.GetPublishersByIds(request.Ids), cancellationToken);
        }
    }
}
