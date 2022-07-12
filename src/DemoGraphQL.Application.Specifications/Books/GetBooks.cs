using Ardalis.Specification;
using DemoGraphQL.Domain;

namespace DemoGraphQL.Application.Specifications.Books
{
    public class GetBooks : Specification<Book>
    {
        public GetBooks()
        {
            Query
                .Include(b => b.Author)
                .Include(b => b.Publisher);
        }
    }
}
