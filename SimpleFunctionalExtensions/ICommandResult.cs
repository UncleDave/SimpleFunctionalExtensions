namespace SimpleFunctionalExtensions
{
    public interface ICommandResult
    {
        bool IsSuccess { get; }

        bool IsFailure { get; }
    }

    public interface ICommandResult<out T> : ICommandResult
    {
        T Error { get; }
    }
}