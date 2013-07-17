using System.Collections.Generic;

namespace Pipeliner.Business
{
    public class PipelineDescription
    {
        public IPipelineStarter Starter { get; set; }

        public List<IPipelineStepDescription> Steps { get; set; }

        public string Name { get; set; }
    }
    

    public interface IPipelineStepDescription
    {
        IPipelineStepTrigger Trigger { get; set; }
    }

    public interface IPipelineStepTrigger
    {
    }
}