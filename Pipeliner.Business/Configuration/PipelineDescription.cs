using System.Collections.Generic;

namespace Pipeliner.Business.Configuration
{
    public class PipelineDescription
    {
        public IPipelineStarter Starter { get; set; }

        public List<IPipelineStepDescription> Steps { get; set; }

        public string Name { get; set; }
    }
}