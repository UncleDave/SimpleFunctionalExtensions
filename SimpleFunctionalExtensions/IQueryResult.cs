namespace SimpleFunctionalExtensions
{
    public interface IQueryResult<out T> : ICommandResult
    {
        T Value { get; }
    }

    public interface IQueryResult<out TValue, out TError> : IQueryResult<TValue>
    {
        TError Error { get; }
    }
}