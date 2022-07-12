namespace DemoGraphQL.Application.Mediator.Queries.Authors
{
    public class GetAuthorsQueryHandler : BaseQueryHandler<GetAuthorsQuery, IList<Author>>
    {
        private readonly IRepository<Author> _authorRepository;

        public GetAuthorsQueryHandler(IRepository<Author> authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public override async Task<IList<Author>> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
        {
            return await _authorRepository.ListAsync(cancellationToken);
        }
    }
}
