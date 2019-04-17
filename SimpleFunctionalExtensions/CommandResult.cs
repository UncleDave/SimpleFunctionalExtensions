namespace SimpleFunctionalExtensions
{
    /// <inheritdoc cref="ICommandResult"/>
    public class CommandResult : Result, ICommandResult
    {
        private CommandResult(bool isSuccess) : base(isSuccess) { }

        /// <summary>
        /// Creates a successful <see cref="ICommandResult"/>.
        /// </summary>
        /// <returns>A new <see cref="ICommandResult"/> in the success state.</returns>
        public static ICommandResult Ok() => new CommandResult(true);

        /// <summary>
        /// Creates a failed <see cref="ICommandResult"/>.
        /// </summary>
        /// <returns>A new <see cref="ICommandResult"/> in the failure state.</returns>
        public static ICommandResult Fail() => new CommandResult(false);

        public IQueryResult<T> ToQueryResult<T>(T value) => IsSuccess ? QueryResult<T>.Ok(value) : QueryResult<T>.Fail();
    }

    /// <inheritdoc cref="ICommandResult{T}"/>
    public class CommandResult<T> : Result, ICommandResult<T>
    {
        /// <inheritdoc cref="IErrorResult{T}.Error"/>
        public T Error { get; }

        private CommandResult() : base(true) { }

        private CommandResult(T error) : base(false) => Error = error;

        /// <inheritdoc cref="CommandResult.Ok"/>
        public static ICommandResult<T> Ok() => new CommandResult<T>();

        /// <summary>
        /// Creates a failed <see cref="ICommandResult"/> with the given error.
        /// </summary>
        /// <param name="error">The error that caused the failure.</param>
        /// <returns>A new <see cref="ICommandResult"/> in the failure state with the given error.</returns>
        public static ICommandResult<T> Fail(T error) => new CommandResult<T>(error);

        public IQueryResult<TResult, T> ToQueryResult<TResult>(TResult value) => IsSuccess ? QueryResult<TResult, T>.Ok(value) : QueryResult<TResult, T>.Fail(Error);
    }
}