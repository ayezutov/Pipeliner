using NUnit.Framework;

namespace Pipeliner.Business.Tests
{
    [TestFixture]
    public class PipelineDescriptionValidatorTests
    {
        private PipelineDescriptionValidator validator;

        [SetUp]
        public void Init()
        {
            validator = new PipelineDescriptionValidator();
        }

        [Test]
        public void EnsureThatListOfStepsIsNotEmpty()
        {
            var result = validator.Validate(new PipelineDescription());

            Assert.That(result.IsValid, Is.EqualTo(false));
        }
    }
}