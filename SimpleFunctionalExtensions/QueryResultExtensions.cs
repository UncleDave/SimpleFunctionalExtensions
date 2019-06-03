using System;

namespace SimpleFunctionalExtensions
{
    public static class QueryResultExtensions
    {
        public static QueryResult<T> Catch<T>(this QueryResult<T> result, Func<QueryResult<T>> errorHandler) =>
            result.IsFailure ? errorHandler() : result;

        public static QueryResult<TValue, TError> Catch<TValue, TError>(this QueryResult<TValue, TError> result, Func<TError, QueryResult<TValue, TError>> errorHandler) =>
            result.IsFailure ? errorHandler(result.Error) : result;
    }
}