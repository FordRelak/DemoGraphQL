namespace DemoGraphQL.Domain
{
    public class Publisher: IId<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IList<Book> Books { get; set; } = new List<Book>();
    }
}
