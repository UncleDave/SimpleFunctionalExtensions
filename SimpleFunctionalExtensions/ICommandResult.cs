namespace SimpleFunctionalExtensions
{
    /// <inheritdoc cref="IResult"/>
    public interface ICommandResult : IResult
    {
        IQueryResult<T> ToQueryResult<T>(T value);
    }

    /// <inheritdoc cref="IErrorResult{T}"/>
    public interface ICommandResult<out T> : IErrorResult<T>
    {
        IQueryResult<TResult, T> ToQueryResult<TResult>(TResult value);
    }
}