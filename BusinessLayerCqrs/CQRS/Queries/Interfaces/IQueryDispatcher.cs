namespace Cqrs.Queries.Interfaces
{
    public interface IQueryDispatcher
    {
        TResult Execute<TQuery, TResult>(TQuery query)
            where TQuery : IQuery<TResult>
            where TResult : IQueryResult;
    }
}
