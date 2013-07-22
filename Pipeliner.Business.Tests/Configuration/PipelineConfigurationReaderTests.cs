using System.IO;
using System.Linq;
using System.Text;
using Autofac;
using NSubstitute;
using NUnit.Framework;
using Pipeliner.Business.Configuration;
using Pipeliner.Business.Tests.Fixtures;
using Pipeliner.DataAccess;

namespace Pipeliner.Business.Tests.Configuration
{
    [TestFixture]
    public class PipelineConfigurationReaderTests
    {
        private const string FileName = "test.xaml";
        private PipelineConfigurationReader reader;
        private Stream stream;

        [TestFixtureSetUp]
        public void Init()
        {
            var fileSystem = Substitute.For<IFileSystem>();
            fileSystem
                .GetReadonlyFileStream(Arg.Any<string>())
                .Returns(info => stream);

            var container = new TestContainerRegistrations()
                .GetPreconfiguredContainer(b => b.RegisterInstance(fileSystem).As<IFileSystem>());

            reader = container.Resolve<PipelineConfigurationReader>();
        }

        [Test]
        public void CanReadEmptyConfiguration()
        {
            stream = GetStream(@"
<PipelineConfiguration xmlns=""clr-namespace:Pipeliner.Business.Configuration;assembly=Pipeliner.Business""></PipelineConfiguration>
");

            var configuration = reader.Read(FileName);

            Assert.That(configuration, Is.Not.Null);
        }

        [Test]
        public void CanReadConfigurationWithPipelineDescriptions()
        {
            stream = GetStream(@"
<PipelineConfiguration xmlns=""clr-namespace:Pipeliner.Business.Configuration;assembly=Pipeliner.Business"">
    <PipelineDescription Name=""Pipeline1""></PipelineDescription>
    <PipelineDescription Name=""Pipeline2""></PipelineDescription>
</PipelineConfiguration>
");

            var configuration = reader.Read(FileName);

            Assert.That(configuration.PipelineDescriptions, Is.Not.Null);
            Assert.That(configuration.PipelineDescriptions.Count, Is.EqualTo(2));
        }

        [Test]
        public void CanReadConfigurationWithAttachingCustomStarter()
        {
            stream = GetStream(@"
<PipelineConfiguration xmlns=""clr-namespace:Pipeliner.Business.Configuration;assembly=Pipeliner.Business"" xmlns:test=""clr-namespace:Pipeliner.Business.Tests.ExtensibilityTesting;assembly=Pipeliner.Business.Tests"">
    <PipelineDescription Name=""Pipeline1"">
        <PipelineDescription.Starter>
            <test:CustomPipelineStarter/>
        </PipelineDescription.Starter>
    </PipelineDescription>
</PipelineConfiguration>
");

            var configuration = reader.Read(FileName);

            Assert.That(configuration.PipelineDescriptions.First().Starter, Is.Not.Null);
        }

        [Test]
        public void CanReadConfigurationWithStepsInPipeline()
        {
            stream = GetStream(@"
<PipelineConfiguration xmlns=""clr-namespace:Pipeliner.Business.Configuration;assembly=Pipeliner.Business"" xmlns:test=""clr-namespace:Pipeliner.Business.Tests.ExtensibilityTesting;assembly=Pipeliner.Business.Tests"">
    <PipelineDescription Name=""Pipeline1"">
        <PipelineDescription.Starter>
            <test:CustomPipelineStarter/>
        </PipelineDescription.Starter>
        <PipelineDescription.Steps>
            <test:CustomPipelineStep Name=""P1_S1""/>
            <test:CustomPipelineStep Name=""P1_S2""/>
            <test:CustomPipelineStep Name=""P1_S3""/>
        </PipelineDescription.Steps>
    </PipelineDescription>
</PipelineConfiguration>
");

            var configuration = reader.Read(FileName);

            var pipeline = configuration.PipelineDescriptions.First();
            Assert.That(pipeline.Steps, Is.Not.Null);
            Assert.That(pipeline.Steps.Count, Is.EqualTo(3));
            Assert.That(pipeline.Steps[0].Name, Is.EqualTo("P1_S1"));
            Assert.That(pipeline.Steps[1].Name, Is.EqualTo("P1_S2"));
            Assert.That(pipeline.Steps[2].Name, Is.EqualTo("P1_S3"));
        }

        private Stream GetStream(string s)
        {
            return new MemoryStream(Encoding.UTF8.GetBytes(s));
        }
    }
}