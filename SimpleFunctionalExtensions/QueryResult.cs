using System;

namespace SimpleFunctionalExtensions
{
    public class QueryResult<T> : ValueResult<T>
    {
        private QueryResult() : base(false) { }

        private QueryResult(T value) : base(value) { }

        public static QueryResult<T> Ok(T value) => new QueryResult<T>(value);

        public static QueryResult<T> Fail() => new QueryResult<T>();

        public QueryResult<TResult> Map<TResult>(Func<T, TResult> mapper) => IsSuccess ? new QueryResult<TResult>(mapper(Value)) : new QueryResult<TResult>();

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

        public static implicit operator QueryResult<TValue, TError>(TValue value) => new QueryResult<TValue, TError>(value);
    }
}