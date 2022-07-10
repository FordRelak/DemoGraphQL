using Ardalis.Specification;

namespace DemoGraphQL.Application.Repositories
{
    public interface IRepository<T> : IRepositoryBase<T> where T : class
    {
    }
}
