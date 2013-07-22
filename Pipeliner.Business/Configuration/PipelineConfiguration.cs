using System.Collections.Generic;
using System.Windows.Markup;

namespace Pipeliner.Business.Configuration
{
    [ContentProperty("PipelineDescriptions")]
    public class PipelineConfiguration
    {
        public PipelineConfiguration()
        {
            PipelineDescriptions = new List<PipelineDescription>();
        }

        public IList<PipelineDescription> PipelineDescriptions { get; private set; }
    }
}