namespace DemoGraphQL.Application.Mediator.Handlers.Books
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Book>
    {
        private readonly IRepository<Book> _bookRepository;

        public UpdateBookCommandHandler(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Book> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            await _bookRepository.UpdateAsync(request.Book, cancellationToken);
            return request.Book;
        }
    }
}
