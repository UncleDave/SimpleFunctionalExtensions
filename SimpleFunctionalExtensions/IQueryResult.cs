using System;

namespace SimpleFunctionalExtensions
{
    public interface IQueryResult<out T> : IValueResult<T>
    {
        IQueryResult<TResult> Map<TResult>(Func<T, TResult> mapper);
    }

    public interface IQueryResult<out TValue, out TError> : IValueResult<TValue>, IErrorResult<TError>
    {
        IQueryResult<TResult, TError> Map<TResult>(Func<TValue, TResult> mapper);
    }
}