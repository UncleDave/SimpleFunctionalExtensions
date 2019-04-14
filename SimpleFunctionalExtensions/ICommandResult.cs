namespace SimpleFunctionalExtensions
{
    /// <summary>
    /// Represents the successful or unsuccessful outcome of a task.
    /// </summary>
    public interface ICommandResult
    {
        /// <summary>
        /// Gets whether this <see cref="ICommandResult"/> is a success.
        /// </summary>
        bool IsSuccess { get; }

        /// <summary>
        /// Gets whether this <see cref="ICommandResult"/> is a failure.
        /// </summary>
        bool IsFailure { get; }
    }

    /// <inheritdoc cref="ICommandResult"/>
    /// <summary>
    /// Unsuccessful results contain an error of type <see cref="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of the error produced when the task fails.</typeparam>
    public interface ICommandResult<out T> : ICommandResult
    {
        /// <summary>
        /// The error that caused this <see cref="ICommandResult{T}"/> to fail.
        /// Null if <see cref="ICommandResult.IsSuccess"/> is true.
        /// </summary>
        T Error { get; }
    }
}