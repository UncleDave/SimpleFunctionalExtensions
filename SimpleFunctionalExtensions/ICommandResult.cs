namespace SimpleFunctionalExtensions
{
    /// <inheritdoc cref="IResult"/>
    public interface ICommandResult : IResult { }

    /// <inheritdoc cref="IErrorResult{T}"/>
    public interface ICommandResult<out T> : IErrorResult<T> { }
}