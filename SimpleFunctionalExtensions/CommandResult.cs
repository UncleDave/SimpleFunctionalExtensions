using System;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace SimpleFunctionalExtensions
{
    /// <inheritdoc cref="IResult"/>
    public class CommandResult : Result
    {
        private CommandResult(bool isSuccess) : base(isSuccess) { }

        /// <summary>
        /// Creates a successful <see cref="CommandResult"/>.
        /// </summary>
        /// <returns>A new <see cref="CommandResult"/> in the success state.</returns>
        public static CommandResult Ok() => new CommandResult(true);

        /// <summary>
        /// Creates a failed <see cref="CommandResult"/>.
        /// </summary>
        /// <returns>A new <see cref="CommandResult"/> in the failure state.</returns>
        public static CommandResult Fail() => new CommandResult(false);

        public QueryResult<T> ToQueryResult<T>(T value) => IsSuccess ? QueryResult<T>.Ok(value) : QueryResult<T>.Fail();

        public CommandResult Catch(Func<CommandResult> errorHandler) => IsFailure ? errorHandler() : this;

        public Task<CommandResult> CatchAsync(Func<Task<CommandResult>> errorHandler) => IsFailure ? errorHandler() : Task.FromResult(this);
    }

    /// <inheritdoc cref="IErrorResult{T}"/>
    public class CommandResult<T> : Result, IErrorResult<T>
    {
        /// <inheritdoc cref="IErrorResult{T}.Error"/>
        public T Error { get; }

        private CommandResult() : base(true) { }

        private CommandResult(T error) : base(false) => Error = error;

        /// <inheritdoc cref="CommandResult.Ok"/>
        public static CommandResult<T> Ok() => new CommandResult<T>();

        /// <summary>
        /// Creates a failed <see cref="CommandResult"/> with the given error.
        /// </summary>
        /// <param name="error">The error that caused the failure.</param>
        /// <returns>A new <see cref="CommandResult"/> in the failure state with the given error.</returns>
        public static CommandResult<T> Fail(T error) => new CommandResult<T>(error);

        public QueryResult<TResult, T> ToQueryResult<TResult>(TResult value) => IsSuccess ? QueryResult<TResult, T>.Ok(value) : QueryResult<TResult, T>.Fail(Error);

        public CommandResult<T> Catch(Func<T, CommandResult<T>> errorHandler) => IsFailure ? errorHandler(Error) : this;

        public CommandResult<T> Catch(Func<CommandResult<T>> errorHandler) => IsFailure ? errorHandler() : this;

        public CommandResult<T> CatchWhen(Func<T, bool> condition, Func<T, CommandResult<T>> errorHandler) => IsFailure && condition(Error) ? errorHandler(Error) : this;

        public CommandResult<T> CatchWhen(Func<T, bool> condition, Func<CommandResult<T>> errorHandler) => IsFailure && condition(Error) ? errorHandler() : this;

        public Task<CommandResult<T>> CatchAsync(Func<T, Task<CommandResult<T>>> errorHandler) => IsFailure ? errorHandler(Error) : Task.FromResult(this);

        public Task<CommandResult<T>> CatchAsync(Func<Task<CommandResult<T>>> errorHandler) => IsFailure ? errorHandler() : Task.FromResult(this);

        public Task<CommandResult<T>> CatchWhenAsync(Func<T, bool> condition, Func<T, Task<CommandResult<T>>> errorHandler) =>
            IsFailure && condition(Error) ? errorHandler(Error) : Task.FromResult(this);

        public Task<CommandResult<T>> CatchWhenAsync(Func<T, bool> condition, Func<Task<CommandResult<T>>> errorHandler) =>
            IsFailure && condition(Error) ? errorHandler() : Task.FromResult(this);
    }
}