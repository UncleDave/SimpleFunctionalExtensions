using System;

namespace SimpleFunctionalExtensions
{
    public static class CommandResultExtensions
    {
        public static CommandResult Catch(this CommandResult result, Func<CommandResult> errorHandler) =>
            result.IsFailure ? errorHandler() : result;

        public static CommandResult<T> Catch<T>(this CommandResult<T> result, Func<T, CommandResult<T>> errorHandler) =>
            result.IsFailure ? errorHandler(result.Error) : result;
    }
}