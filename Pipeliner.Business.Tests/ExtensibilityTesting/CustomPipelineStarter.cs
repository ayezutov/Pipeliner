using System;

namespace Pipeliner.Business.Tests.ExtensibilityTesting
{
    public class CustomPipelineStarter : IPipelineStarter
    {
        public event EventHandler<InstanceCreateEventArgs> OnPipelineInstanceCreate;
    }
}