namespace DemoGraphQL.Domain
{
    public interface IId<T>
    {
        public T Id { get; set; }
    }
}