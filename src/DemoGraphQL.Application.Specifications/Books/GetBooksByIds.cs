namespace DemoGraphQL.Application.Specifications.Books
{
    public class GetBooksByIds : Specification<Book>
    {
        public GetBooksByIds(Guid[] ids)
        {
            Query.Where(book => ids.Contains(book.Id));
        }
    }
}
