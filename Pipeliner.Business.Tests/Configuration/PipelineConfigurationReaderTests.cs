using System.IO;
using System.Text;
using NSubstitute;
using NUnit.Framework;
using Pipeliner.Business.Configuration;
using Pipeliner.Business.Tests.Fixtures;
using Autofac;
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

        private Stream GetStream(string s)
        {
            return new MemoryStream(Encoding.UTF8.GetBytes(s));
        }
    }
}