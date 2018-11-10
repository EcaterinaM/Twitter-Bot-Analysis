namespace Cqrs.Queries.Interfaces
{
    public interface IQueryHandler<in TQuery, out TResult>
        where TQuery : IQuery<TResult>
        where TResult : IQueryResult
    {
        TResult Execute(TQuery query);
    }
}
