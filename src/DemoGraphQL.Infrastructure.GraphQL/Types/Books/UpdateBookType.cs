namespace DemoGraphQL.Infrastructure.GraphQL.Types.Books
{
    public class UpdateBookType
    {
        [GraphQLNonNullType]
        public Guid Id { get; set; }

        [GraphQLNonNullType]
        public string Title { get; set; }

        [GraphQLNonNullType]
        public DateTime PublishedDate { get; set; }
    }
}
