using DemoGraphQL.Application.Specifications.Books;

namespace DemoGraphQL.Application.Mediator.Queries.Books.GetBookByIds
{
    public class GetBooksByIdsQueryHandler : IRequestHandler<GetBooksByIdsQuery, IList<Book>>
    {
        private readonly IRepository<Book> _bookRepository;

        public GetBooksByIdsQueryHandler(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IList<Book>> Handle(GetBooksByIdsQuery request, CancellationToken cancellationToken)
        {
            return await _bookRepository.ListAsync(new GetBooksByIds(request.Ids), cancellationToken);
        }
    }
}
