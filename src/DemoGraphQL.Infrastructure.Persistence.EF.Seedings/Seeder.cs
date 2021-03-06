using Bogus;
using DemoGraphQL.Domain;

namespace DemoGraphQL.Infrastructure.Persistence.EF.Seedings
{
    public class Seeder
    {
        private readonly GQDbContext _context;
        private readonly Faker<Publisher> _publisherFaker;
        private readonly Faker<Book> _bookFaker;
        private readonly Faker<Author> _authorFaker;

        public Seeder(GQDbContext context)
        {
            _context = context;

            _publisherFaker = new Faker<Publisher>()
                .RuleFor(p => p.Name, f => f.Name.JobTitle());

            _bookFaker = new Faker<Book>()
                .RuleFor(b => b.Title, f => f.Name.FirstName())
                .RuleFor(b => b.PublicationDate, f => f.Date.Past(60, DateTime.Now.AddYears(-18)));

            _authorFaker = new Faker<Author>()
                .RuleFor(a => a.Name, f => f.Name.FullName());
        }

        public async Task SeedIfNeed()
        {
            if(_context.Books.Any())
            {
                return;
            }

            Publisher p1 = CreatePublisher();
            Publisher p2 = CreatePublisher();

            Author a1 = CreateAuthor();
            Author a2 = CreateAuthor();
            Author a3 = CreateAuthor();

            Book b1 = CreateBook();
            Book b2 = CreateBook();
            Book b3 = CreateBook();
            Book b4 = CreateBook();
            Book b5 = CreateBook();
            Book b6 = CreateBook();

            AddBookToPublisher(p1, b1, b2, b3);
            AddBookToPublisher(p2, b4, b5, b6);

            AddBookToAuthor(a1, b1, b6, b5);
            AddBookToAuthor(a2, b2, b3);
            AddBookToAuthor(a3, b4);

            await _context.Authors.AddRangeAsync(a1, a2);
            await _context.Publishers.AddRangeAsync(p1, p2);
            await _context.Books.AddRangeAsync(b1, b2, b3, b4, b5, b6);

            await _context.SaveChangesAsync();
        }

        private void AddBookToAuthor(Author author, params Book[] books)
        {
            foreach(Book book in books)
            {
                book.Author = author;
                author.Books.Add(book);
            }
        }

        private void AddBookToPublisher(Publisher publisher, params Book[] books)
        {
            foreach(Book book in books)
            {
                book.Publisher = publisher;
                publisher.Books.Add(book);
            }
        }

        private Publisher CreatePublisher()
        {
            return _publisherFaker.Generate();
        }

        private Book CreateBook()
        {
            return _bookFaker.Generate();
        }

        private Author CreateAuthor()
        {
            return _authorFaker.Generate();
        }
    }
}
