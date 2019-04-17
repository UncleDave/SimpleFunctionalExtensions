using SimpleFunctionalExtensions;
using Xunit;
using static Xunit.Assert;

namespace SimpleFunctionalExtensionsTests
{
    public class CommandResultWithErrorTests
    {
        [Fact]
        public void StaticOk_ReturnsICommandResult_WithIsSuccessSetToTrue()
        {
            var result = CommandResult<object>.Ok();

            True(result.IsSuccess);
        }

        [Fact]
        public void StaticOk_ReturnsICommandResult_WithIsFailureSetToFalse()
        {
            var result = CommandResult<object>.Ok();

            False(result.IsFailure);
        }

        [Fact]
        public void StaticOk_ReturnsICommandResult_WithNullError()
        {
            var result = CommandResult<object>.Ok();

            Null(result.Error);
        }

        [Fact]
        public void StaticFail_ReturnsICommandResult_WithIsSuccessSetToFalse()
        {
            var result = CommandResult<object>.Fail(new { });

            False(result.IsSuccess);
        }

        [Fact]
        public void StaticFail_ReturnsICommandResult_WithIsFailureSetToTrue()
        {
            var result = CommandResult<object>.Fail(new { });

            True(result.IsFailure);
        }

        [Fact]
        public void StaticFail_ReturnsICommandResult_WithCorrectError()
        {
            var error = new { };
            var result = CommandResult<object>.Fail(error);

            Same(error, result.Error);
        }

        [Fact]
        public void ToQueryResult_OnSuccessfulResult_ReturnsIQueryResult_WithIsSuccessSetToTrue()
        {
            var result = CommandResult<object>.Ok().ToQueryResult(new { });

            True(result.IsSuccess);
        }

        [Fact]
        public void ToQueryResult_OnSuccessfulResult_ReturnsIQueryResult_WithIsFailureSetToFalse()
        {
            var result = CommandResult<object>.Ok().ToQueryResult(new { });

            False(result.IsFailure);
        }

        [Fact]
        public void ToQueryResult_OnSuccessfulResult_ReturnsIQueryResult_WithCorrectValue()
        {
            var value = new { };
            var result = CommandResult<object>.Ok().ToQueryResult(value);

            Same(value, result.Value);
        }

        [Fact]
        public void ToQueryResult_OnSuccessfulResult_ReturnsIQueryResult_WithNullError()
        {
            var result = CommandResult<object>.Ok().ToQueryResult(new { });

            Null(result.Error);
        }

        [Fact]
        public void ToQueryResult_OnFailedResult_ReturnsIQueryResult_WithIsSuccessSetToFalse()
        {
            var result = CommandResult<object>.Fail(new { }).ToQueryResult(new { });

            False(result.IsSuccess);
        }

        [Fact]
        public void ToQueryResult_OnFailedResult_ReturnsIQueryResult_WithIsFailureSetToTrue()
        {
            var result = CommandResult<object>.Fail(new { }).ToQueryResult(new { });

            True(result.IsFailure);
        }

        [Fact]
        public void ToQueryResult_OnFailedResult_ReturnsIQueryResult_WithCorrectError()
        {
            var error = new { };
            var result = CommandResult<object>.Fail(error).ToQueryResult(new { });

            Same(error, result.Error);
        }

        [Fact]
        public void ToQueryResult_OnFailedResult_ReturnsIQueryResult_WithNullValue()
        {
            var result = CommandResult<object>.Fail(new { }).ToQueryResult(new { });

            Null(result.Value);
        }
    }
}