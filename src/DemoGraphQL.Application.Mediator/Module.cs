using DemoGraphQL.Application.Mediator.Handlers.Books;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DemoGraphQL.Application.Mediator
{
    public static class Module
    {
        public static IServiceCollection ConfigureMediatr(this IServiceCollection services)
        {
            return services.AddMediatR(typeof(UpdateBookCommand).GetTypeInfo().Assembly);
        }
    }
}
