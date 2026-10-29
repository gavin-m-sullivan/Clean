using Clean.Core;
using FluentAssertions;
using System.ComponentModel.DataAnnotations;

namespace CoreTests
{
    public class ResultTests
    {
        [Fact]
        public void Success_ReturnsResult()
        {
            var result = Result<object>.Success(new());

            result.Should().NotBeNull();
            result.Should().BeOfType<Result<object>>();
        }
        [Fact]
        public void Fail_ReturnsResult()
        {
            var result = Result<object>.Fail(new ValidationResult("Error"));

            result.Should().NotBeNull();
            result.Should().BeOfType<Result<object>>();
        }
        [Fact]
        public void Value_ReturnsSuccessfulResultValue()
        {
            var value = new object();
            var result = Result<object>.Success(value);

            result.Value.Should().Be(value);
        }
        [Fact]
        public void Errors_ReturnsFailedResultErrors()
        {
            var result = Result<object>.Fail(new ValidationResult("Error"));

            result.Errors.Should().ContainSingle()
                .Which.ErrorMessage.Should().Be("Error");
        }
        [Fact]
        public void Succeeded_ReturnsStateOfResult()
        {
            var successfulResult = Result<object>.Success(new());

            successfulResult.Succeeded.Should().BeTrue();

            var failedResult = Result<object>.Fail(new ValidationResult("Error"));

            failedResult.Succeeded.Should().BeFalse();
        }
        [Fact]
        public void Failed_ChangesSuccesfulResultToFailedResult()
        {
            var result = Result<object>.Success(new());

            result.Failed(new ValidationResult("Error"));

            result.Succeeded.Should().BeFalse();
            result.Errors.Should().ContainSingle()
                .Which.ErrorMessage.Should().Be("Error");
        }
        [Fact]
        public void Failed_ChangesFailedResultToFailedResult()
        {
            var result = Result<object>.Fail(new ValidationResult("Error1"));

            result.Failed(new ValidationResult("Error2"));

            result.Succeeded.Should().BeFalse();
            result.Errors.Should().HaveCount(2);
            result.Errors.Should().Contain(e => e.ErrorMessage == "Error1");
            result.Errors.Should().Contain(e => e.ErrorMessage == "Error2");
        }
        [Fact]
        public void Value_ThrowsIfFailedResult()
        {
            var result = Result<object>.Fail(new ValidationResult("Error"));

            Action act = () => { _ = result.Value; };

            act.Should().Throw<InvalidOperationException>();
        }
        [Fact]
        public void Errors_ThrowsIfSuccessResult()
        {
            var result = Result<object>.Success(new());

            Action act = () => { _ = result.Errors; };

            act.Should().Throw<InvalidOperationException>();
        }
    }
}
