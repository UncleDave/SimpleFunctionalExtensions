namespace SimpleFunctionalExtensions
{
    /// <summary>
    /// <inheritdoc cref="IResult"/>
    /// Unsuccessful results contain an error of type <see cref="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of the error produced when the task fails.</typeparam>
    public interface IErrorResult<out T> : IResult
    {
        /// <summary>
        /// The error that caused this <see cref="IErrorResult{T}"/> to fail.
        /// Null if <see cref="IErrorResult{T}.IsSuccess"/> is true.
        /// </summary>
        T Error { get; }
    }
}
