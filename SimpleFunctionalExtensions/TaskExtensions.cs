﻿using System;
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
    }
}