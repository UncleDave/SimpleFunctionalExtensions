namespace SimpleFunctionalExtensions
{
    public class CommandResult : Result
    {
        private CommandResult(bool isSuccess) : base(isSuccess) { }

        public static ICommandResult Ok() => new CommandResult(true);

        public static ICommandResult Fail() => new CommandResult(false);
    }

    public class CommandResult<T> : Result, ICommandResult<T>
    {
        public T Error { get; }

        private CommandResult() : base(true) { }

        private CommandResult(T error) : base(false) => Error = error;

        public static ICommandResult<T> Ok() => new CommandResult<T>();

        public static ICommandResult<T> Fail(T error) => new CommandResult<T>(error);
    }
}