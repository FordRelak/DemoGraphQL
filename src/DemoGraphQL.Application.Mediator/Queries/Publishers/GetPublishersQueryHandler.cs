namespace DemoGraphQL.Application.Mediator.Queries.Publishers
{
    public class GetPublishersQueryHandler : BaseQueryHandler<GetPublishersQuery, IList<PublisherDTO>>
    {
        private readonly IRepository<Publisher> _publisherRepository;

        public GetPublishersQueryHandler(
            IMapper mapper,
            IRepository<Publisher> publisherRepository) : base(mapper)
        {
            _publisherRepository = publisherRepository;
        }

        public override async Task<IList<PublisherDTO>> Handle(GetPublishersQuery request, CancellationToken cancellationToken)
        {
            var publishers = await _publisherRepository.ListAsync(cancellationToken);
            return _mapper.Map<IList<PublisherDTO>>(publishers);
        }
    }
}