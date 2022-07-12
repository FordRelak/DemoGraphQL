﻿using DemoGraphQL.Application.Mediator.Queries.Books;
using DemoGraphQL.Domain;
using MediatR;

namespace DemoGraphQL.Infrastructure.GraphQL.Queries
{
    [ExtendObjectType(typeof(Query))]
    public class SimpleQuery
    {
        public async Task<IList<Book>> GetBooks([Service] IMediator mediator, CancellationToken cancellationToken)
        {
            return await mediator.Send(new GetBooksQuery(), cancellationToken);
        }
    }
}