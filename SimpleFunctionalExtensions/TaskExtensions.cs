using System;
using System.Threading.Tasks;

namespace SimpleFunctionalExtensions
{
    public static class TaskExtensions
    {
        public static async Task<IQueryResult<TResult>> MapAsync<TSource, TResult>(this Task<IQueryResult<TSource>> task, Func<TSource, TResult> mapper)
        {
            var result = await task;

            return result.Map(mapper);
        }

        public static async Task<IQueryResult<TResult, TError>> MapAsync<TSource, TResult, TError>(this Task<IQueryResult<TSource, TError>> task, Func<TSource, TResult> mapper)
        {
            var result = await task;

            return result.Map(mapper);
        }

        public static async Task<IQueryResult<T>> ToQueryResultAsync<T>(this Task<ICommandResult> task, T value)
        {
            var result = await task;

            return result.ToQueryResult(value);
        }

        public static async Task<IQueryResult<TResult, TError>> ToQueryResultAsync<TResult, TError>(this Task<ICommandResult<TError>> task, TResult value)
        {
            var result = await task;

            return result.ToQueryResult(value);
        }
    }
}