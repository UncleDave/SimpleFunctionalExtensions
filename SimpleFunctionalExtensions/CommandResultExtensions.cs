using System;

namespace SimpleFunctionalExtensions
{
    public static class CommandResultExtensions
    {
        public static ICommandResult Catch(this ICommandResult result, Func<ICommandResult> errorHandler) =>
            result.IsFailure ? errorHandler() : result;

        public static ICommandResult<T> Catch<T>(this ICommandResult<T> result, Func<T, ICommandResult<T>> errorHandler) =>
            result.IsFailure ? errorHandler(result.Error) : result;
    }
}