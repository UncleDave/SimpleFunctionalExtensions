using SimpleFunctionalExtensions;
using Xunit;
using static Xunit.Assert;

namespace SimpleFunctionalExtensionsTests
{
    public class QueryResultWithErrorTests
    {
        [Fact]
        public void StaticOk_ReturnsQueryResult_WithIsSuccessSetToTrue()
        {
            var result = QueryResult<object, object>.Ok(new { });

            True(result.IsSuccess);
        }

        [Fact]
        public void StaticOk_ReturnsQueryResult_WithIsFailureSetToFalse()
        {
            var result = QueryResult<object, object>.Ok(new { });

            False(result.IsFailure);
        }

        [Fact]
        public void StaticOk_ReturnsQueryResult_WithCorrectValue()
        {
            var value = new { };
            var result = QueryResult<object, object>.Ok(value);

            Same(value, result.Value);
        }

        [Fact]
        public void StaticOk_ReturnsQueryResult_WithNullError()
        {
            var result = QueryResult<object, object>.Ok(new { });

            Null(result.Error);
        }

        [Fact]
        public void StaticFail_ReturnsQueryResult_WithIsSuccessSetToFalse()
        {
            var result = QueryResult<object, object>.Fail(new { });

            False(result.IsSuccess);
        }

        [Fact]
        public void StaticFail_ReturnsQueryResult_WithIsFailureSetToTrue()
        {
            var result = QueryResult<object, object>.Fail(new { });

            True(result.IsFailure);
        }

        [Fact]
        public void StaticFail_ReturnsQueryResult_WithCorrectError()
        {
            var error = new { };
            var result = QueryResult<object, object>.Fail(error);

            Same(error, result.Error);
        }

        [Fact]
        public void StaticFail_ReturnsQueryResult_WithNullValue()
        {
            var result = QueryResult<object, object>.Fail(new { });

            Null(result.Value);
        }

        [Fact]
        public void Map_OnSuccessfulResult_ReturnsQueryResult_WithIsSuccessSetToTrue()
        {
            var result = QueryResult<object, object>.Ok(new { }).Map(x => new { });

            True(result.IsSuccess);
        }

        [Fact]
        public void Map_OnSuccessfulResult_ReturnsQueryResult_WithIsFailureSetToFalse()
        {
            var result = QueryResult<object, object>.Ok(new { }).Map(x => new { });

            False(result.IsFailure);
        }

        [Fact]
        public void Map_OnSuccessfulResult_ReturnsQueryResult_WithCorrectValue()
        {
            var value = new { };
            var result = QueryResult<object, object>.Ok(new { }).Map(x => value);

            Same(value, result.Value);
        }

        [Fact]
        public void Map_OnSuccessfulResult_ReturnsQueryResult_WithNullError()
        {
            var result = QueryResult<object, object>.Ok(new { }).Map(x => new { });

            Null(result.Error);
        }

        [Fact]
        public void Map_OnFailedResult_ReturnsQueryResult_WithIsSuccessSetToFalse()
        {
            var result = QueryResult<object, object>.Fail(new { }).Map(x => new { });

            False(result.IsSuccess);
        }

        [Fact]
        public void Map_OnFailedResult_ReturnsQueryResult_WithIsFailureSetToTrue()
        {
            var result = QueryResult<object, object>.Fail(new { }).Map(x => new { });

            True(result.IsFailure);
        }

        [Fact]
        public void Map_OnFailedResult_ReturnsQueryResult_WithCorrectError()
        {
            var error = new { };
            var result = QueryResult<object, object>.Fail(error).Map(x => new { });

            Same(error, result.Error);
        }

        [Fact]
        public void Map_OnFailedResult_ReturnsQueryResult_WithNullValue()
        {
            var result = QueryResult<object, object>.Fail(new { }).Map(x => new { });

            Null(result.Value);
        }

        [Fact]
        public void Map_OnFailedResult_DoesNotCallMapper()
        {
            var calls = 0;

            object Mapper(object x)
            {
                calls++;

                return new { };
            }

            QueryResult<object>.Fail().Map(Mapper);

            Equal(0, calls);
        }
    }
}