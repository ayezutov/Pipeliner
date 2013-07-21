namespace Pipeliner.Business.Configuration
{
    public interface IPipelineConfigurationReader
    {
        PipelineConfiguration Read(string fileName);
    }

    public class PipelineConfiguration
    {

    }
}