namespace SimpleFunctionalExtensions
{
    public abstract class Result : ICommandResult
    {
        public bool IsSuccess { get; }

        public bool IsFailure => !IsSuccess;

        protected Result(bool isSuccess) => IsSuccess = isSuccess;
    }
}