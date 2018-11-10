namespace Cqrs.Queries.Interfaces
{
    public interface IQuery<TResult> where TResult : IQueryResult
    {
    }
}
