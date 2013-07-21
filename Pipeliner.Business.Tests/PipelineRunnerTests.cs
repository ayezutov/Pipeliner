using Autofac;
using NSubstitute;
using NUnit.Framework;
using Pipeliner.Business.Tests.Fixtures;

namespace Pipeliner.Business.Tests
{
    [TestFixture]
    public class PipelineRunnerTests
    {
        private IPipelineStarter starter;
        private IStorage storage;
        private IInstanceCreator instanceCreator;
        private PipelineRunner runner;
        private PipelineDescription description;

        [SetUp]
        public void Init()
        {
            starter = Substitute.For<IPipelineStarter>();
            instanceCreator = Substitute.For<IInstanceCreator>();
            storage = Substitute.For<IStorage>();
            instanceCreator.CreateInstance().Returns(info => new PipelineInstance());

            var container = new TestContainerRegistrations()
                .GetPreconfiguredContainer(builder =>
                {
                    builder.RegisterInstance(starter);
                    builder.RegisterInstance(instanceCreator);
                    builder.RegisterInstance(storage);
                });

            runner = container.Resolve<PipelineRunner>();

            description = new PipelineDescription { Starter = starter };
        }

        [Test]
        public void EnsureStarterTriggersNewPipelineInstanceCreation()
        {
            runner.Run(description);

            storage.DidNotReceive().AddPipeline(Arg.Any<PipelineInstance>());

            starter.EmulatePipelineInstanceEvent();

            storage.Received(1).AddPipeline(Arg.Any<PipelineInstance>());
        } 
        
        [Test]
        public void EnsureStarterParametersArePassedToInstanceCreator()
        {
            PipelineInstance instance = null;
            storage.AddPipeline(Arg.Do<PipelineInstance>(i => instance = i));

            runner.Run(description);

            starter.EmulatePipelineInstanceEvent(new InstanceCreateEventArgs
            {
                Parameters = { { "TestParam1", "XXX" }, { "TestParam2", "YYY" } }
            });

            storage.Received(1).AddPipeline(Arg.Any<PipelineInstance>());

            Assert.That(instance.Context.Parameters["TestParam1"], Is.EqualTo("XXX"));
            Assert.That(instance.Context.Parameters["TestParam2"], Is.EqualTo("YYY"));
        }
    }
}