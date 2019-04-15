namespace SimpleFunctionalExtensions
{
    public interface IValueResult<out T> : IResult
    {
        T Value { get; }
    }
}