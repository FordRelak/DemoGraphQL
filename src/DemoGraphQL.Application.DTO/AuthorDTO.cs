using DemoGraphQL.Domain;

namespace DemoGraphQL.Application.DTO
{
    public class AuthorDTO : IId<Guid>
    {
        public Guid Id { get; set; }


        public string Name { get; set; }

        public IList<BookDTO> Books { get; set; } = new List<BookDTO>();
    }
}