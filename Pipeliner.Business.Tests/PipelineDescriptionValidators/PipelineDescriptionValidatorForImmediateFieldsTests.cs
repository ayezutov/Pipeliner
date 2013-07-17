// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PipelineDescriptionValidatorForImmediateFieldsTests.cs" company="">
//   
// </copyright>
// <summary>
//   The pipeline description validator for immediate fields tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using Pipeliner.Business.PipelineDescriptionValidators;

namespace Pipeliner.Business.Tests.PipelineDescriptionValidators
{
    /// <summary>
    /// The pipeline description validator for immediate fields tests.
    /// </summary>
    [TestFixture]
    public class PipelineDescriptionValidatorForImmediateFieldsTests
    {
        /// <summary>
        /// The validator.
        /// </summary>
        private PipelineDescriptionValidatorForImmediateFields validator;

        /// <summary>
        /// The init.
        /// </summary>
        [SetUp]
        public void Init()
        {
            validator = new PipelineDescriptionValidatorForImmediateFields();
        }

        /// <summary>
        /// The ensure that list of steps is not null.
        /// </summary>
        [Test]
        public void EnsureThatListOfStepsIsNotNull()
        {
            var result = validator.Validate(new PipelineDescription());

            Assert.That(result.IsValid, Is.EqualTo(false));
        }

        /// <summary>
        /// The ensure that list of steps is not empty.
        /// </summary>
        [Test]
        public void EnsureThatListOfStepsIsNotEmpty()
        {
            var result = validator.Validate(new PipelineDescription
                                                {
                                                    Steps = new List<IPipelineStepDescription>()
                                                });

            Assert.That(result.IsValid, Is.EqualTo(false));
        }

    }
}