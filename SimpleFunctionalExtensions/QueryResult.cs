namespace SimpleFunctionalExtensions
{
    public class QueryResult<T> : ValueResult<T>
    {
        public QueryResult(bool isSuccess) : base(isSuccess) { }

        public QueryResult(T value) : base(value) { }

        public static IQueryResult<T> Ok(T value) => new QueryResult<T>(value);

        public static IQueryResult<T> Fail() => new QueryResult<T>(false);
    }

    public class QueryResult<TValue, TError> : ValueResult<TValue>, IQueryResult<TValue, TError>
    {
        public TError Error { get; }

        public QueryResult(TValue value) : base(value) { }

        public QueryResult(TError error) : base(false) => Error = error;

        public static IQueryResult<TValue, TError> Ok(TValue value) => new QueryResult<TValue, TError>(value);

        public static IQueryResult<TValue, TError> Fail(TError error) => new QueryResult<TValue, TError>(error);
    }
}