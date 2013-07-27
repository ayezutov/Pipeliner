using System;

namespace Pipeliner.Business.Providers.Starters
{
    public class ManualPipelineStarter : IPipelineStarter
    {
        public event EventHandler<InstanceCreateEventArgs> OnPipelineInstanceCreate;
    }
}
