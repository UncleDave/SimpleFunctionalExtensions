using SimpleFunctionalExtensions;
using Xunit;
using static Xunit.Assert;

namespace SimpleFunctionalExtensionsTests
{
    public class CommandResultTests
    {
        [Fact]
        public void StaticOk_ReturnsCommandResult_WithIsSuccessSetToTrue()
        {
            var result = CommandResult.Ok();

            True(result.IsSuccess);
        }

        [Fact]
        public void StaticOk_ReturnsCommandResult_WithIsFailureSetToFalse()
        {
            var result = CommandResult.Ok();

            False(result.IsFailure);
        }

        [Fact]
        public void StaticFail_ReturnsCommandResult_WithIsSuccessSetToFalse()
        {
            var result = CommandResult.Fail();

            False(result.IsSuccess);
        }

        [Fact]
        public void StaticFail_ReturnsCommandResult_WithIsFailureSetToTrue()
        {
            var result = CommandResult.Fail();

            True(result.IsFailure);
        }

        [Fact]
        public void ToQueryResult_OnSuccessfulResult_ReturnsQueryResult_WithIsSuccessSetToTrue()
        {
            var result = CommandResult.Ok().ToQueryResult(new { });

            True(result.IsSuccess);
        }

        [Fact]
        public void ToQueryResult_OnSuccessfulResult_ReturnsQueryResult_WithIsFailureSetToFalse()
        {
            var result = CommandResult.Ok().ToQueryResult(new { });

            False(result.IsFailure);
        }

        [Fact]
        public void ToQueryResult_OnSuccessfulResult_ReturnsQueryResult_WithCorrectValue()
        {
            var value = new { };
            var result = CommandResult.Ok().ToQueryResult(value);

            Same(value, result.Value);
        }

        [Fact]
        public void ToQueryResult_OnFailedResult_ReturnsQueryResult_WithIsSuccessSetToFalse()
        {
            var result = CommandResult.Fail().ToQueryResult(new { });

            False(result.IsSuccess);
        }

        [Fact]
        public void ToQueryResult_OnFailedResult_ReturnsQueryResult_WithIsFailureSetToTrue()
        {
            var result = CommandResult.Fail().ToQueryResult(new { });

            True(result.IsFailure);
        }

        [Fact]
        public void ToQueryResult_OnFailedResult_ReturnsQueryResult_WithNullValue()
        {
            var result = CommandResult.Fail().ToQueryResult(new { });

            Null(result.Value);
        }

        [Fact]
        public void Catch_OnSuccessfulResult_ReturnsCorrectCommandResult()
        {
            var originalResult = CommandResult.Ok();
            var result = originalResult.Catch(CommandResult.Fail);

            Same(originalResult, result);
        }

        [Fact]
        public void Catch_OnFailedResult_ReturnsCorrectCommandResult()
        {
            var handledResult = CommandResult.Ok();
            var result = CommandResult.Fail().Catch(() => handledResult);

            Same(handledResult, result);
        }
    }
}