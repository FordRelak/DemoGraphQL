namespace DemoGraphQL.Infrastructure.GraphQL.Types.Books
{
    public class AddBookType
    {
        [GraphQLNonNullType]
        public string Title { get; set; }

        [GraphQLNonNullType]
        public Guid AuthorId { get; set; }

        [GraphQLNonNullType]
        public Guid PublisherId { get; set; }

        [GraphQLNonNullType]
        public DateTime PublicationDate { get; set; }
    }
}
