namespace DemoGraphQL.Application.Specifications.Publishers
{
    public class GetPublishersByIds : Specification<Publisher>
    {
        public GetPublishersByIds(Guid[] ids)
        {
            Query.Where(publisher => ids.Contains(publisher.Id));
        }
    }
}
