namespace SimpleFunctionalExtensions
{
    public class CommandResult : Result
    {
        public CommandResult(bool isSuccess) : base(isSuccess) { }

        public static ICommandResult Ok() => new CommandResult(true);

        public static ICommandResult Fail() => new CommandResult(false);
    }

    public class CommandResult<T> : Result, ICommandResult<T>
    {
        public T Error { get; }

        public CommandResult(bool isSuccess) : base(isSuccess) { }

        public CommandResult(T error) : base(false) => Error = error;

        public static ICommandResult Ok() => new CommandResult<T>(true);

        public static ICommandResult Fail(T error) => new CommandResult<T>(error);
    }
}