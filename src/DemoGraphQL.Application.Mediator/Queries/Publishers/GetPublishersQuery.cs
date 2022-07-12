using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoGraphQL.Application.Mediator.Queries.Publishers
{
    public record GetPublishersQuery : IRequest<IList<Publisher>>;
}
