using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using Pipeliner.Business.Configuration;
using Pipeliner.Business.PipelineDescriptionValidators;

namespace Pipeliner.Business.Tests.PipelineDescriptionValidators
{
    /// <summary>
    /// The pipeline description validator for steps tests.
    /// </summary>
    [TestFixture]
    public class PipelineDescriptionValidatorForStepsTests
    {
        /// <summary>
        /// The validator.
        /// </summary>
        private PipelineDescriptionValidatorForSteps validator;

        /// <summary>
        /// The init.
        /// </summary>
        [SetUp]
        public void Init()
        {
            validator = new PipelineDescriptionValidatorForSteps();
        }

        /// <summary>
        /// The ensure that first step has empty trigger.
        /// </summary>
        [Test]
        public void EnsureThatFirstStepHasEmptyTrigger()
        {
            var step = Substitute.For<IPipelineStepDescription>();
            step.Trigger.Returns((IPipelineStepTrigger)null);

            var result = validator.Validate(new PipelineDescription
                                                {
                                                    Steps = { step }
                                                });

            Assert.That(result.IsValid, Is.EqualTo(true));
        }

        /// <summary>
        /// The ensure that validation occurs if first step has not empty trigger.
        /// </summary>
        [Test]
        public void EnsureThatValidationOccursIfFirstStepHasNotEmptyTrigger()
        {
            var step = Substitute.For<IPipelineStepDescription>();
            step.Trigger.Returns(Substitute.For<IPipelineStepTrigger>());

            var result = validator.Validate(new PipelineDescription
                                                {
                                                    Steps = { step }
                                                });

            Assert.That(result.IsValid, Is.EqualTo(false));
        }
    }
}