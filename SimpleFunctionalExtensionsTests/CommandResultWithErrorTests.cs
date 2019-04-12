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
    }
}