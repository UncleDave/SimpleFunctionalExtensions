using System;

namespace SimpleFunctionalExtensions
{
    public static class CommandResultExtensions
    {
        public static ICommandResult Catch(this ICommandResult result, Func<CommandResult> errorHandler) =>
            result.IsFailure ? errorHandler() : result;

        public static ICommandResult<T> Catch<T>(this ICommandResult<T> result, Func<T, CommandResult<T>> errorHandler) =>
            result.IsFailure ? errorHandler(result.Error) : result;
    }
}