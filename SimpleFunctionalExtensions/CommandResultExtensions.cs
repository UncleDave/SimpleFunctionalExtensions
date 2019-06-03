using System;

namespace SimpleFunctionalExtensions
{
    public static class CommandResultExtensions
    {
        public static CommandResult Catch(this CommandResult result, Func<CommandResult> errorHandler) =>
            result.IsFailure ? errorHandler() : result;

        public static CommandResult<T> Catch<T>(this CommandResult<T> result, Func<T, CommandResult<T>> errorHandler) =>
            result.IsFailure ? errorHandler(result.Error) : result;

        public static CommandResult<T> Catch<T>(this CommandResult<T> result, Func<CommandResult<T>> errorHandler) =>
            result.IsFailure ? errorHandler() : result;

        public static CommandResult<T> CatchWhen<T>(this CommandResult<T> result, Func<T, bool> condition, Func<T, CommandResult<T>> errorHandler)
        {
            if (result.IsFailure)
                return condition(result.Error) ? errorHandler(result.Error) : result;

            return result;
        }

        public static CommandResult<T> CatchWhen<T>(this CommandResult<T> result, Func<T, bool> condition, Func<CommandResult<T>> errorHandler)
        {
            if (result.IsFailure)
                return condition(result.Error) ? errorHandler() : result;

            return result;
        }
    }
}