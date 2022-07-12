namespace DemoGraphQL.Application.Mediator.Handlers.Books
{
    public class AddBookQueryCommand : IRequestHandler<AddBookCommand, Book>
    {
        private readonly IRepository<Book> _bookRepository;

        public AddBookQueryCommand(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Book> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            await _bookRepository.AddAsync(request.Book, cancellationToken);
            return request.Book;
        }
    }
}
