using System;

namespace SimpleFunctionalExtensions
{
    public static class QueryResultExtensions
    {
        public static IQueryResult<T> Catch<T>(this IQueryResult<T> result, Func<IQueryResult<T>> errorHandler) =>
            result.IsFailure ? errorHandler() : result;

        public static IQueryResult<TValue, TError> Catch<TValue, TError>(this IQueryResult<TValue, TError> result, Func<TError, IQueryResult<TValue, TError>> errorHandler) =>
            result.IsFailure ? errorHandler(result.Error) : result;
    }
}