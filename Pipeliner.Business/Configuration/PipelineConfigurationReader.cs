using System.Windows.Markup;
using System.Xaml;
using Pipeliner.DataAccess;

namespace Pipeliner.Business.Configuration
{
    public class PipelineConfigurationReader : IPipelineConfigurationReader
    {
        private readonly IFileSystem fileSystem;

        public PipelineConfigurationReader(IFileSystem fileSystem)
        {
            this.fileSystem = fileSystem;
        }

        public PipelineConfiguration Read(string fileName)
        {
            return (PipelineConfiguration)XamlServices.Load(fileSystem.GetReadonlyFileStream(fileName));
        }
    }
}