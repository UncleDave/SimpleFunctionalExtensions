namespace SimpleFunctionalExtensions
{
    public interface IValueResult<out T> : ICommandResult
    {
        T Value { get; }
    }
}