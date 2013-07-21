using System;
using Autofac;

namespace Pipeliner.Business.Tests.Fixtures
{
    public class TestContainerRegistrations
    {
        public IContainer GetPreconfiguredContainer(Action<ContainerBuilder> actions)
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(typeof (PipelineRunner).Assembly);
            actions(builder);

            return builder.Build();
        }
    }
}