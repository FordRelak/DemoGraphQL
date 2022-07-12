namespace DemoGraphQL.Application.Mediator.Queries.Publishers
{
    public class GetPublishersQueryHandler : BaseQueryHandler<GetPublishersQuery, IList<Publisher>>
    {
        private readonly IRepository<Publisher> _publisherRepository;

        public GetPublishersQueryHandler(IRepository<Publisher> publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        public override async Task<IList<Publisher>> Handle(GetPublishersQuery request, CancellationToken cancellationToken)
        {
            return await _publisherRepository.ListAsync(cancellationToken);
        }
    }
}
