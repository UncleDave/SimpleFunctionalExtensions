using System;

namespace SimpleFunctionalExtensions
{
    public static class QueryResultExtensions
    {
        public static QueryResult<T> Catch<T>(this QueryResult<T> result, Func<QueryResult<T>> errorHandler) =>
            result.IsFailure ? errorHandler() : result;

        public static QueryResult<TValue, TError> Catch<TValue, TError>(this QueryResult<TValue, TError> result, Func<TError, QueryResult<TValue, TError>> errorHandler) =>
            result.IsFailure ? errorHandler(result.Error) : result;

        public static QueryResult<TValue, TError> Catch<TValue, TError>(this QueryResult<TValue, TError> result, Func<QueryResult<TValue, TError>> errorHandler) =>
            result.IsFailure ? errorHandler() : result;

        public static QueryResult<TValue, TError> CatchWhen<TValue, TError>(
            this QueryResult<TValue, TError> result,
            Func<TError, bool> condition,
            Func<TError, QueryResult<TValue, TError>> errorHandler)
        {
            if (result.IsFailure)
                return condition(result.Error) ? errorHandler(result.Error) : result;

            return result;
        }

        public static QueryResult<TValue, TError> CatchWhen<TValue, TError>(
            this QueryResult<TValue, TError> result,
            Func<TError, bool> condition,
            Func<QueryResult<TValue, TError>> errorHandler)
        {
            if (result.IsFailure)
                return condition(result.Error) ? errorHandler() : result;

            return result;
        }
    }
}