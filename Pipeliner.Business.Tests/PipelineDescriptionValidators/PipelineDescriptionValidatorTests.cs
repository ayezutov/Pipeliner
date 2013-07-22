using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using Pipeliner.Business.Configuration;
using Pipeliner.Business.PipelineDescriptionValidators;

namespace Pipeliner.Business.Tests
{
    [TestFixture]
    public class PipelineDescriptionValidatorTests
    {
        [Test]
        public void EnsureAllTheValidatorsAreCalled()
        {
            var validators = new[]
                                 {
                                     GetValidator(),
                                     GetValidator(),
                                     GetValidator()
                                 };

            var validator = new PipelineDescriptionValidator(validators);
            validator.Validate(new PipelineDescription());

            validators[0].Received(1).Validate(Arg.Any<PipelineDescription>());
            validators[1].Received(1).Validate(Arg.Any<PipelineDescription>());
            validators[2].Received(1).Validate(Arg.Any<PipelineDescription>());
        }

        [Test]
        public void EnsureAllTheValidatorsAreCalledUntilFirstUnsuccessful()
        {
            var validators = new[]
                                 {
                                     GetValidator(),
                                     GetValidator(isSuccessful: false),
                                     GetValidator()
                                 };

            var validator = new PipelineDescriptionValidator(validators);
            validator.Validate(new PipelineDescription());

            validators[0].Received(1).Validate(Arg.Any<PipelineDescription>());
            validators[1].Received(1).Validate(Arg.Any<PipelineDescription>());
            validators[2].DidNotReceive().Validate(Arg.Any<PipelineDescription>());
        }

        private static IValidator<PipelineDescription> GetValidator(bool isSuccessful = true, string message = null)
        {
            var validator = Substitute.For<IValidator<PipelineDescription>>();
            validator.Validate(Arg.Any<PipelineDescription>()).Returns(isSuccessful ? ValidationResult.Success : ValidationResult.Invalid(message));
            return validator;
        }
    }

}