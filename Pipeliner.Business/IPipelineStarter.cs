using System;

namespace Pipeliner.Business
{
    public interface IPipelineStarter
    {
        event EventHandler<InstanceCreateEventArgs> OnPipelineInstanceCreate;
    }
}