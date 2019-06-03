using SimpleFunctionalExtensions;
using Xunit;
using static Xunit.Assert;

namespace SimpleFunctionalExtensionsTests
{
    public class QueryResultTests
    {
        [Fact]
        public void StaticOk_ReturnsQueryResult_WithIsSuccessSetToTrue()
        {
            var result = QueryResult<object>.Ok(new { });

            True(result.IsSuccess);
        }

        [Fact]
        public void StaticOk_ReturnsQueryResult_WithIsFailureSetToFalse()
        {
            var result = QueryResult<object>.Ok(new { });

            False(result.IsFailure);
        }

        [Fact]
        public void StaticOk_ReturnsQueryResult_WithCorrectValue()
        {
            var value = new { };
            var result = QueryResult<object>.Ok(value);

            Same(value, result.Value);
        }

        [Fact]
        public void StaticFail_ReturnsQueryResult_WithIsSuccessSetToFalse()
        {
            var result = QueryResult<object>.Fail();

            False(result.IsSuccess);
        }

        [Fact]
        public void StaticFail_ReturnsQueryResult_WithIsFailureSetToTrue()
        {
            var result = QueryResult<object>.Fail();

            True(result.IsFailure);
        }

        [Fact]
        public void StaticFail_ReturnsQueryResult_WithNullValue()
        {
            var result = QueryResult<object>.Fail();

            Null(result.Value);
        }

        [Fact]
        public void Map_OnSuccessfulResult_ReturnsQueryResult_WithIsSuccessSetToTrue()
        {
            var result = QueryResult<object>.Ok(new { }).Map(x => new { });

            True(result.IsSuccess);
        }

        [Fact]
        public void Map_OnSuccessfulResult_ReturnsQueryResult_WithIsFailureSetToFalse()
        {
            var result = QueryResult<object>.Ok(new { }).Map(x => new { });

            False(result.IsFailure);
        }

        [Fact]
        public void Map_OnSuccessfulResult_ReturnsQueryResult_WithCorrectValue()
        {
            var value = new { };
            var result = QueryResult<object>.Ok(new { }).Map(x => value);

            Same(value, result.Value);
        }

        [Fact]
        public void Map_OnFailedResult_ReturnsQueryResult_WithIsSuccessSetToFalse()
        {
            var result = QueryResult<object>.Fail().Map(x => new { });

            False(result.IsSuccess);
        }

        [Fact]
        public void Map_OnFailedResult_ReturnsQueryResult_WithIsFailureSetToTrue()
        {
            var result = QueryResult<object>.Fail().Map(x => new { });

            True(result.IsFailure);
        }

        [Fact]
        public void Map_OnFailedResult_ReturnsQueryResult_WithNullValue()
        {
            var result = QueryResult<object>.Fail().Map(x => new { });

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