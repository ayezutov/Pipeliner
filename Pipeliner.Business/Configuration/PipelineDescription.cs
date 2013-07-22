using System.Collections.Generic;

namespace Pipeliner.Business.Configuration
{
    public class PipelineDescription
    {
        public PipelineDescription()
        {
            Steps = new List<IPipelineStepDescription>();
        }

        public IPipelineStarter Starter { get; set; }

        public List<IPipelineStepDescription> Steps { get; private set; }

        public string Name { get; set; }
    }
}