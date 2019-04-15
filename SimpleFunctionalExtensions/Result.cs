namespace SimpleFunctionalExtensions
{
    public abstract class Result : IResult
    {
        public bool IsSuccess { get; }

        public bool IsFailure => !IsSuccess;

        protected Result(bool isSuccess) => IsSuccess = isSuccess;
    }
}