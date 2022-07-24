namespace DemoGraphQL.Infrastructure.GraphQL.Mutations.AddAuthor
{
    public class AddAuthorInputType : InputObjectType<AddAuthorInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<AddAuthorInput> descriptor)
        {
            descriptor.Description("Модель добавления нового автора");

            descriptor
                .Field(input => input.Name)
                .Type<NonNullType<StringType>>()
                .Description("Имя автора");
        }
    }
}
