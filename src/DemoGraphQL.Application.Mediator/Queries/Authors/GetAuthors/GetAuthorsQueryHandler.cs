namespace DemoGraphQL.Application.Mediator.Queries.Authors
{
    public class GetAuthorsQueryHandler : BaseQueryHandler<GetAuthorsQuery, IList<AuthorDTO>>
    {
        private readonly IRepository<Author> _authorRepository;

        public GetAuthorsQueryHandler(
            IMapper mapper,
            IRepository<Author> authorRepository) : base(mapper)
        {
            _authorRepository = authorRepository;
        }

        public override async Task<IList<AuthorDTO>> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
        {
            var authors = await _authorRepository.ListAsync(cancellationToken);
            return _mapper.Map<IList<AuthorDTO>>(authors);
        }
    }
}