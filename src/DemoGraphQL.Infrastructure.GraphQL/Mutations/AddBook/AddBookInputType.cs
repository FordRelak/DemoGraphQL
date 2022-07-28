namespace DemoGraphQL.Infrastructure.GraphQL.Mutations.AddBook
{
    public class AddBookInputType : InputObjectType<AddBookInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<AddBookInput> descriptor)
        {
            descriptor
                .Field(input => input.Title)
                .Type<NonNullType<StringType>>();

            descriptor
                .Field(input => input.PublisherId)
                .Type<NonNullType<IdType>>();

            descriptor
                .Field(input => input.AuthorId)
                .Type<NonNullType<IdType>>();
        }
    }
}
