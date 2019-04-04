namespace SimpleFunctionalExtensions
{
    public abstract class ValueResult<T> : Result, IQueryResult<T>
    {
        public T Value { get; }

        protected ValueResult(bool isSuccess) : base(isSuccess) { }

        protected ValueResult(T value) : base(true) => Value = value;
    }
}