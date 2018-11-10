using Autofac;
using Cqrs.Queries.Interfaces;
using System;

namespace BusinessLayerCqrs.CQRS.Queries
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IComponentContext _context;

        public QueryDispatcher(IComponentContext context)
        {
            _context = context;
        }

        public TResult Execute<TQuery, TResult>(TQuery query)
            where TQuery : IQuery<TResult>
            where TResult : IQueryResult
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            var handler = _context.Resolve<IQueryHandler<TQuery, TResult>>();

            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            return handler.Execute(query);
        }
    }
}
