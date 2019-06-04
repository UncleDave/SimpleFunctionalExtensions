using System;
using System.Threading.Tasks;

namespace SimpleFunctionalExtensions
{
    public class QueryResult<T> : ValueResult<T>
    {
        private QueryResult() : base(false) { }

        private QueryResult(T value) : base(value) { }

        public static QueryResult<T> Ok(T value) => new QueryResult<T>(value);

        public static QueryResult<T> Fail() => new QueryResult<T>();

        public QueryResult<TResult> Map<TResult>(Func<T, TResult> mapper) => IsSuccess ? new QueryResult<TResult>(mapper(Value)) : new QueryResult<TResult>();

        public QueryResult<T> Catch(Func<QueryResult<T>> errorHandler) => IsFailure ? errorHandler() : this;

        public Task<QueryResult<T>> CatchAsync(Func<Task<QueryResult<T>>> errorHandler) => IsFailure ? errorHandler() : Task.FromResult(this);

        public static implicit operator QueryResult<T>(T value) => new QueryResult<T>(value);
    }

    public class QueryResult<TValue, TError> : ValueResult<TValue>, IErrorResult<TError>
    {
        public TError Error { get; }

        private QueryResult(TValue value) : base(value) { }

        private QueryResult(TError error) : base(false) => Error = error;

        public static QueryResult<TValue, TError> Ok(TValue value) => new QueryResult<TValue, TError>(value);

        public static QueryResult<TValue, TError> Fail(TError error) => new QueryResult<TValue, TError>(error);

        public QueryResult<TResult, TError> Map<TResult>(Func<TValue, TResult> mapper) =>
            IsSuccess ? new QueryResult<TResult, TError>(mapper(Value)) : new QueryResult<TResult, TError>(Error);

        public QueryResult<TValue, TError> Catch(Func<TError, QueryResult<TValue, TError>> errorHandler) => IsFailure ? errorHandler(Error) : this;

        public QueryResult<TValue, TError> Catch(Func<QueryResult<TValue, TError>> errorHandler) => IsFailure ? errorHandler() : this;

        public QueryResult<TValue, TError> CatchWhen(Func<TError, bool> condition, Func<TError, QueryResult<TValue, TError>> errorHandler) =>
            IsFailure && condition(Error) ? errorHandler(Error) : this;

        public QueryResult<TValue, TError> CatchWhen(Func<TError, bool> condition, Func<QueryResult<TValue, TError>> errorHandler) =>
            IsFailure && condition(Error) ? errorHandler() : this;

        public Task<QueryResult<TValue, TError>> CatchAsync(Func<TError, Task<QueryResult<TValue, TError>>> errorHandler) => IsFailure ? errorHandler(Error) : Task.FromResult(this);

        public Task<QueryResult<TValue, TError>> CatchAsync(Func<Task<QueryResult<TValue, TError>>> errorHandler) => IsFailure ? errorHandler() : Task.FromResult(this);

        public Task<QueryResult<TValue, TError>> CatchWhenAsync(Func<TError, bool> condition, Func<TError, Task<QueryResult<TValue, TError>>> errorHandler) =>
            IsFailure && condition(Error) ? errorHandler(Error) : Task.FromResult(this);

        public Task<QueryResult<TValue, TError>> CatchWhenAsync(Func<TError, bool> condition, Func<Task<QueryResult<TValue, TError>>> errorHandler) =>
            IsFailure && condition(Error) ? errorHandler() : Task.FromResult(this);

        public static implicit operator QueryResult<TValue, TError>(TValue value) => new QueryResult<TValue, TError>(value);
    }
}