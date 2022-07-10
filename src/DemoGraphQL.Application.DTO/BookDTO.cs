using DemoGraphQL.Domain;

namespace DemoGraphQL.Application.DTO
{
    public class BookDTO : IId<Guid>
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public AuthorDTO Author { get; set; }

        public PublisherDTO Publisher { get; set; }

        public DateTime PublicationDate { get; set; }
    }
}