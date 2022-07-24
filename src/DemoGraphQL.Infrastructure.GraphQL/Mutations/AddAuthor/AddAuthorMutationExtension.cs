using DemoGraphQL.Domain;

namespace DemoGraphQL.Infrastructure.GraphQL.Mutations.AddAuthor
{
    public class AddAuthorMutationExtension : ObjectTypeExtension<Mutation>
    {
        protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
        {
            descriptor
                .Field(nameof(AddAuthorResolver.AddAuthorAsync).ToGqlQueryName())
                .Argument("input", argument => argument.Type<NonNullType<AddAuthorInputType>>())
                .ResolveWith<AddAuthorResolver>(resolver => resolver.AddAuthorAsync(default!, default!, default))
                .UseDbContext<GQDbContext>()
                .Description("Добавление автора");
        }

        private class AddAuthorResolver
        {
            public async Task<AddAuthorPayload> AddAuthorAsync(
                AddAuthorInput input,
                [ScopedService] GQDbContext context,
                CancellationToken cancellationToken)
            {
                Author author = new()
                {
                    Name = input.Name,
                };

                await context.AddAsync(author, cancellationToken);
                await context.SaveChangesAsync(cancellationToken);

                return new(author.Id, author.Name);
            }
        }
    }
}
