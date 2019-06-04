using System;
using System.Threading.Tasks;

namespace SimpleFunctionalExtensions
{
    public static class TaskExtensions
    {
        public static async Task<QueryResult<TResult>> MapAsync<TSource, TResult>(this Task<QueryResult<TSource>> task, Func<TSource, TResult> mapper)
        {
            var result = await task;

            return result.Map(mapper);
        }

        public static async Task<QueryResult<TResult, TError>> MapAsync<TSource, TResult, TError>(this Task<QueryResult<TSource, TError>> task, Func<TSource, TResult> mapper)
        {
            var result = await task;

            return result.Map(mapper);
        }

        public static async Task<QueryResult<T>> ToQueryResultAsync<T>(this Task<CommandResult> task, T value)
        {
            var result = await task;

            return result.ToQueryResult(value);
        }

        public static async Task<QueryResult<TResult, TError>> ToQueryResultAsync<TResult, TError>(this Task<CommandResult<TError>> task, TResult value)
        {
            var result = await task;

            return result.ToQueryResult(value);
        }

        public static async Task<CommandResult> CatchAsync(this Task<CommandResult> task, Func<CommandResult> errorHandler)
        {
            var result = await task;

            return result.Catch(errorHandler);
        }

        public static async Task<CommandResult<T>> CatchAsync<T>(this Task<CommandResult<T>> task, Func<T, CommandResult<T>> errorHandler)
        {
            var result = await task;

            return result.Catch(errorHandler);
        }

        public static async Task<CommandResult<T>> CatchAsync<T>(this Task<CommandResult<T>> task, Func<CommandResult<T>> errorHandler)
        {
            var result = await task;

            return result.Catch(errorHandler);
        }

        public static async Task<CommandResult> CatchAsync(this Task<CommandResult> task, Func<Task<CommandResult>> errorHandler)
        {
            var result = await task;

            return await result.CatchAsync(errorHandler);
        }

        public static async Task<CommandResult<T>> CatchAsync<T>(this Task<CommandResult<T>> task, Func<T, Task<CommandResult<T>>> errorHandler)
        {
            var result = await task;

            return await result.CatchAsync(errorHandler);
        }

        public static async Task<CommandResult<T>> CatchAsync<T>(this Task<CommandResult<T>> task, Func<Task<CommandResult<T>>> errorHandler)
        {
            var result = await task;

            return await result.CatchAsync(errorHandler);
        }

        public static async Task<QueryResult<T>> CatchAsync<T>(this Task<QueryResult<T>> task, Func<QueryResult<T>> errorHandler)
        {
            var result = await task;

            return result.Catch(errorHandler);
        }

        public static async Task<QueryResult<TValue, TError>> CatchAsync<TValue, TError>(this Task<QueryResult<TValue, TError>> task, Func<TError, QueryResult<TValue, TError>> errorHandler)
        {
            var result = await task;

            return result.Catch(errorHandler);
        }

        public static async Task<QueryResult<TValue, TError>> CatchAsync<TValue, TError>(this Task<QueryResult<TValue, TError>> task, Func<QueryResult<TValue, TError>> errorHandler)
        {
            var result = await task;

            return result.Catch(errorHandler);
        }

        public static async Task<QueryResult<T>> CatchAsync<T>(this Task<QueryResult<T>> task, Func<Task<QueryResult<T>>> errorHandler)
        {
            var result = await task;

            return await result.CatchAsync(errorHandler);
        }

        public static async Task<QueryResult<TValue, TError>> CatchAsync<TValue, TError>(this Task<QueryResult<TValue, TError>> task, Func<TError, Task<QueryResult<TValue, TError>>> errorHandler)
        {
            var result = await task;

            return await result.CatchAsync(errorHandler);
        }

        public static async Task<QueryResult<TValue, TError>> CatchAsync<TValue, TError>(this Task<QueryResult<TValue, TError>> task, Func<Task<QueryResult<TValue, TError>>> errorHandler)
        {
            var result = await task;

            return await result.CatchAsync(errorHandler);
        }

        public static async Task<CommandResult<T>> CatchWhenAsync<T>(this Task<CommandResult<T>> task, Func<T, bool> condition, Func<T, CommandResult<T>> errorHandler)
        {
            var result = await task;

            return result.CatchWhen(condition, errorHandler);
        }

        public static async Task<CommandResult<T>> CatchWhenAsync<T>(this Task<CommandResult<T>> task, Func<T, bool> condition, Func<CommandResult<T>> errorHandler)
        {
            var result = await task;

            return result.CatchWhen(condition, errorHandler);
        }

        public static async Task<CommandResult<T>> CatchWhenAsync<T>(this Task<CommandResult<T>> task, Func<T, bool> condition, Func<T, Task<CommandResult<T>>> errorHandler)
        {
            var result = await task;

            return await result.CatchWhenAsync(condition, errorHandler);
        }

        public static async Task<CommandResult<T>> CatchWhenAsync<T>(this Task<CommandResult<T>> task, Func<T, bool> condition, Func<Task<CommandResult<T>>> errorHandler)
        {
            var result = await task;

            return await result.CatchWhenAsync(condition, errorHandler);
        }

        public static async Task<QueryResult<TValue, TError>> CatchWhenAsync<TValue, TError>(
            this Task<QueryResult<TValue, TError>> task,
            Func<TError, bool> condition,
            Func<TError, QueryResult<TValue, TError>> errorHandler)
        {
            var result = await task;

            return result.CatchWhen(condition, errorHandler);
        }

        public static async Task<QueryResult<TValue, TError>> CatchWhenAsync<TValue, TError>(
            this Task<QueryResult<TValue, TError>> task,
            Func<TError, bool> condition,
            Func<QueryResult<TValue, TError>> errorHandler)
        {
            var result = await task;

            return result.CatchWhen(condition, errorHandler);
        }

        public static async Task<QueryResult<TValue, TError>> CatchWhenAsync<TValue, TError>(
            this Task<QueryResult<TValue, TError>> task,
            Func<TError, bool> condition,
            Func<TError, Task<QueryResult<TValue, TError>>> errorHandler)
        {
            var result = await task;

            return await result.CatchWhenAsync(condition, errorHandler);
        }

        public static async Task<QueryResult<TValue, TError>> CatchWhenAsync<TValue, TError>(
            this Task<QueryResult<TValue, TError>> task,
            Func<TError, bool> condition,
            Func<Task<QueryResult<TValue, TError>>> errorHandler)
        {
            var result = await task;

            return await result.CatchWhenAsync(condition, errorHandler);
        }
    }
}