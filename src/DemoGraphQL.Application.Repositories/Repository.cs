using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DemoGraphQL.Application.Repositories
{
    public class Repository<T> : RepositoryBase<T>, IRepository<T> where T : class
    {
        public Repository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
