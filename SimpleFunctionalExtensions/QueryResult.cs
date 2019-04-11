using System;

namespace SimpleFunctionalExtensions
{
    public class QueryResult<T> : ValueResult<T>, IQueryResult<T>
    {
        private QueryResult() : base(false) { }

        private QueryResult(T value) : base(value) { }

        public static IQueryResult<T> Ok(T value) => new QueryResult<T>(value);

        public static IQueryResult<T> Fail() => new QueryResult<T>();

        public IQueryResult<TResult> Map<TResult>(Func<T, TResult> mapper) => IsSuccess ? new QueryResult<TResult>(mapper(Value)) : new QueryResult<TResult>();
    }

    public class QueryResult<TValue, TError> : ValueResult<TValue>, IQueryResult<TValue, TError>
    {
        public TError Error { get; }

        private QueryResult(TValue value) : base(value) { }

        private QueryResult(TError error) : base(false) => Error = error;

        public static IQueryResult<TValue, TError> Ok(TValue value) => new QueryResult<TValue, TError>(value);

        public static IQueryResult<TValue, TError> Fail(TError error) => new QueryResult<TValue, TError>(error);

        public IQueryResult<TResult, TError> Map<TResult>(Func<TValue, TResult> mapper) =>
            IsSuccess ? new QueryResult<TResult, TError>(mapper(Value)) : new QueryResult<TResult, TError>(Error);
    }
}