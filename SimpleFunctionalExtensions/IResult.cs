namespace SimpleFunctionalExtensions
{
    /// <summary>
    /// Represents the successful or unsuccessful outcome of a task.
    /// </summary>
    public interface IResult
    {
        /// <summary>
        /// Gets whether this <see cref="CommandResult"/> is a success.
        /// </summary>
        bool IsSuccess { get; }

        /// <summary>
        /// Gets whether this <see cref="CommandResult"/> is a failure.
        /// </summary>
        bool IsFailure { get; }
    }
}
