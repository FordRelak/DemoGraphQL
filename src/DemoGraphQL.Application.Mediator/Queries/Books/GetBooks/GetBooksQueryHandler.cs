namespace DemoGraphQL.Application.Mediator.Queries.Books
{
    public class GetBooksQueryHandler : BaseQueryHandler<GetBooksQuery, IList<Book>>
    {
        private readonly IRepository<Book> _bookRepository;

        public GetBooksQueryHandler(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public override async Task<IList<Book>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            return await _bookRepository.ListAsync(cancellationToken);
        }
    }
}
