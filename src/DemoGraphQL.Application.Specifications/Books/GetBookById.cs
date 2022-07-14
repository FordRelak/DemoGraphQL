namespace DemoGraphQL.Application.Specifications.Books
{
    public class GetBookById : Specification<Book>, ISingleResultSpecification<Book>
    {
        public GetBookById(Guid bookId)
        {
            Query.Where(book => book.Id == bookId);
        }
    }
}
