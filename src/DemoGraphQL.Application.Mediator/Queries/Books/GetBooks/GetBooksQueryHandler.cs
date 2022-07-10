namespace DemoGraphQL.Application.Mediator.Queries.Books
{
    public class GetBooksQueryHandler : BaseQueryHandler<GetBooksQuery, IList<BookDTO>>
    {
        private readonly IRepository<Book> _bookRepository;

        public GetBooksQueryHandler(
            IMapper mapper,
            IRepository<Book> bookRepository) : base(mapper)
        {
            _bookRepository = bookRepository;
        }

        public override async Task<IList<BookDTO>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.ListAsync(cancellationToken);
            return _mapper.Map<IList<BookDTO>>(books);
        }
    }
}
