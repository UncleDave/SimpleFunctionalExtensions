namespace SimpleFunctionalExtensions
{
    public abstract class ValueResult<T> : Result, IValueResult<T>
    {
        public T Value { get; }

        protected ValueResult(bool isSuccess) : base(isSuccess) { }

        protected internal ValueResult(T value) : base(true) => Value = value;
    }
}