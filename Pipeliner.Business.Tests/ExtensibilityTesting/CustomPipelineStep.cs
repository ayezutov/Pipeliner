using Pipeliner.Business.Configuration;

namespace Pipeliner.Business.Tests.ExtensibilityTesting
{
    public class CustomPipelineStep : IPipelineStepDescription
    {
        public IPipelineStepTrigger Trigger { get; set; }

        public string Name { get; set; }
    }
}