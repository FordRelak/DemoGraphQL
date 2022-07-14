using DemoGraphQL.Application.Specifications.Books;

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
            Book? dbBook = await _bookRepository.SingleOrDefaultAsync(new GetBookById(request.Book.Id), cancellationToken);

            dbBook.Title = request.Book.Title;

            await _bookRepository.UpdateAsync(dbBook, cancellationToken);
            return dbBook;
        }
    }
}
