namespace DemoGraphQL.Domain
{
    public class Book : IId<Guid>
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public Guid AuthorId { get; set; }

        public Author Author { get; set; }

        public Guid PublisherId { get; set; }

        public Publisher Publisher { get; set; }

        public DateTime PublicationDate { get; set; }
    }
}
