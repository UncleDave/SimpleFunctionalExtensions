using SimpleFunctionalExtensions;
using Xunit;
using static Xunit.Assert;

namespace SimpleFunctionalExtensionsTests
{
    public class CommandResultTests
    {
        [Fact]
        public void StaticOk_ReturnsICommandResult_WithIsSuccessSetToTrue()
        {
            var result = CommandResult.Ok();

            True(result.IsSuccess);
        }

        [Fact]
        public void StaticOk_ReturnsICommandResult_WithIsFailureSetToFalse()
        {
            var result = CommandResult.Ok();

            False(result.IsFailure);
        }

        [Fact]
        public void StaticFail_ReturnsICommandResult_WithIsSuccessSetToFalse()
        {
            var result = CommandResult.Fail();

            False(result.IsSuccess);
        }

        [Fact]
        public void StaticFail_ReturnsICommandResult_WithIsFailureSetToTrue()
        {
            var result = CommandResult.Fail();

            True(result.IsFailure);
        }
    }
}