using NSubstitute;
using NUnit.Framework;
using Pipeliner.Business.Tests.Fixtures;

namespace Pipeliner.Business.Tests
{
    [TestFixture]
    public class PipelineRunnerTests
    {
        [Test]
        public void EnsureStarterTriggersNewPipelineInstanceCreation()
        {
            var starter = Substitute.For<IPipelineStarter>();
            var instanceCreator = Substitute.For<IInstanceCreator>();
            
            var description = new PipelineDescription
            {
                Starter = starter
            };

            
            new PipelineRunner(instanceCreator).Run(description);

            instanceCreator.DidNotReceive().CreateInstance();

            starter.EmulatePipelineInstanceEvent();

            instanceCreator.Received(1).CreateInstance();
        }
    }
}